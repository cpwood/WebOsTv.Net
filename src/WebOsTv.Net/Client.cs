using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using WebOsTv.Net.Auth;
using WebOsTv.Net.Commands;
using WebOsTv.Net.Commands.Api;
using WebOsTv.Net.Commands.Tv;
using WebOsTv.Net.Exceptions;
using WebOsTv.Net.Factory;
using WebOsTv.Net.FileSystem;
using WebOsTv.Net.Json;
using WebOsTv.Net.Responses;
using WebOsTv.Net.Responses.Api;
using WebOsTv.Net.WebSockets;

namespace WebOsTv.Net
{
    public class Client : IDisposable, IClient
    {
        private readonly IKeyStore _keyStore;
        private readonly IFactory<ISocketConnection> _socketFactory;
        private readonly ILogger<Client> _logger;

        private readonly ConcurrentDictionary<string, TaskCompletionSource<Message>> _completionSources =
            new ConcurrentDictionary<string, TaskCompletionSource<Message>>();

        private ISocketConnection _socket;
        private ISocketConnection _mouseSocket;

        private string _hostName;

        public int CommandTimeout { get; set; } = 5000;

        public Client() : this(
            new KeyStore(new FileService()),
            new Factory<ISocketConnection>(() => new SocketConnection()),
            new NullLogger<Client>())
        {
        }

        public Client(IKeyStore keyStore, ILogger<Client> logger) : this(keyStore, new Factory<ISocketConnection>(() => new SocketConnection()), logger)
        {
        }

        internal Client(IKeyStore keyStore, IFactory<ISocketConnection> socketFactory, ILogger<Client> logger)
        {
            _keyStore = keyStore;
            _socketFactory = socketFactory;
            _logger = logger;
        }

        public async Task ConnectAsync(string hostName)
        {
            Close();

            _socket = _socketFactory.Create();
            _socket.OnMessage += OnMessage;
            _socket.Connect($"ws://{hostName}:3000");

            if (!_socket.IsAlive)
                throw new ConnectionException($"Unable to conenct to television at {hostName}.");

            _hostName = hostName;

            var key = await _keyStore.GetKeyAsync(hostName);

            var handshakeCommand = new HandshakeCommand(key);
            var handshakeResponse = await SendCommandAsync<HandshakeResponse>(handshakeCommand);
            await _keyStore.StoreKeyAsync(hostName, handshakeResponse.ClientKey);

            var mouseCommand = new MouseGetCommand();
            var mouseGetResponse = await SendCommandAsync<MouseGetResponse>(mouseCommand);

            _mouseSocket = _socketFactory.Create();
            _mouseSocket.Connect(mouseGetResponse.SocketPath);

            if (!_mouseSocket.IsAlive)
                throw new ConnectionException($"Unable to conenct to television mouse service at {hostName}.");
        }

        public virtual async Task<TResponse> SendCommandAsync<TResponse>(CommandBase command) where TResponse : ResponseBase
        {
            if (!_socket.IsAlive)
                await ConnectAsync(_hostName);

            var request = new Message
            {
                Uri = command.Uri,
                Type = "request",
                Payload = command.ToJObject()
            };

            if (!string.IsNullOrEmpty(command.CustomId))
                request.Id = command.CustomId;

            if (!string.IsNullOrEmpty(command.CustomType))
                request.Type = command.CustomType;

            var taskSource = new TaskCompletionSource<Message>();
            
            _completionSources.TryAdd(request.Id, taskSource);

            var json = JsonConvert.SerializeObject(request, SerializationSettings.Default);

            _logger.LogTrace($"Sending: {json}");

            _socket.Send(json);

            var timeoutTask = Task.Delay(CommandTimeout);
            var responseTask = taskSource.Task;

            if (await Task.WhenAny(timeoutTask, responseTask) == responseTask)
            {
                var response = responseTask.Result;
                return response.Payload.ToObject<TResponse>(
                    JsonSerializer.CreateDefault(SerializationSettings.Default));
            }

            _completionSources.TryRemove(request.Id, out _);
            throw new TimeoutException();
        }

        internal void OnMessage(object sender, SocketMessageEventArgs e)
        {
            _logger.LogTrace($"Received: {e.Data}");

            var response = JsonConvert.DeserializeObject<Message>(e.Data, SerializationSettings.Default);

            if (_completionSources.TryRemove(response.Id, out var taskCompletion))
            {
                if (response.Type == "error")
                    taskCompletion.TrySetException(new CommandException(response.Error));
                else
                    taskCompletion.TrySetResult(response);
            }
        }

        public async Task SendButtonAsync(ButtonTypes type)
        {
            if (!_mouseSocket.IsAlive)
                await ConnectAsync(_hostName);

            _logger.LogTrace($"Sending Button: {type}");

            _mouseSocket.Send($"type:button\nname:{type.ToString().ToUpperInvariant()}\n\n");
        }

        public void Close()
        {
            _socket?.Close();
            _socket = null;

            _mouseSocket?.Close();
            _mouseSocket = null;
        }

        public void Dispose()
        {
            Close();
        }

        internal void SetSocketsForTesting(ISocketConnection main, ISocketConnection mouse)
        {
            _socket = main;
            _mouseSocket = mouse;
        }
    }
}
