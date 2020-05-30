using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using WebOsTv.Net.Auth;
using WebOsTv.Net.Commands;
using WebOsTv.Net.Commands.Api;
using WebOsTv.Net.Commands.Audio;
using WebOsTv.Net.Commands.Tv;
using WebOsTv.Net.Exceptions;
using WebOsTv.Net.Factory;
using WebOsTv.Net.Responses.Api;
using WebOsTv.Net.Responses.Audio;
using WebOsTv.Net.WebSockets;
using Xunit;

namespace WebOsTv.Net.Tests
{
    public class ClientTests
    {
        [Fact]
        public async void ConnectAndCloseSuccessful()
        {
            var keyStoreMock = CreateKeyStore();
            var keyStore = keyStoreMock.Object;

            var mainSocketMock = CreateSocketConnection("ws://thehost:3000");
            var mainSocket = mainSocketMock.Object;

            var mouseSocketMock = CreateSocketConnection("ws://thehost:3000/mouse");
            var mouseSocket = mouseSocketMock.Object;

            var factoryMock = CreateFactory(mainSocket, mouseSocket);
            var factory = factoryMock.Object;

            var clientMock = new Mock<Client>(keyStore, factory, new NullLogger<Client>());

            clientMock.Setup(x => x.SendCommandAsync<HandshakeResponse>(It.IsAny<HandshakeCommand>())).ReturnsAsync(
                new HandshakeResponse
                {
                    ReturnValue = true,
                    Key = "abc123"
                });

            clientMock.Setup(x => x.SendCommandAsync<MouseGetResponse>(It.IsAny<MouseGetCommand>())).ReturnsAsync(
                new MouseGetResponse
                {
                    ReturnValue = true,
                    SocketPath = "ws://thehost:3000/mouse"
                });

            var client = clientMock.Object;

            await client.ConnectAsync("thehost");

            client.Close();

            keyStoreMock.Verify(x => x.GetKeyAsync("thehost"));
            keyStoreMock.Verify(x => x.StoreKeyAsync("thehost", "abc123"));

            mainSocketMock.Verify(x => x.Connect("ws://thehost:3000"));
            mainSocketMock.Verify(x => x.Close());

            mouseSocketMock.Verify(x => x.Connect("ws://thehost:3000/mouse"));
            mouseSocketMock.Verify(x => x.Close());
        }

        [Fact]
        public async void ConnectAndCloseFailsMainSocket()
        {
            var keyStoreMock = CreateKeyStore();
            var keyStore = keyStoreMock.Object;

            var mainSocketMock = CreateSocketConnection("ws://thehost:3000", false);
            var mainSocket = mainSocketMock.Object;

            var mouseSocketMock = CreateSocketConnection("ws://thehost:3000/mouse");
            var mouseSocket = mouseSocketMock.Object;

            var factoryMock = CreateFactory(mainSocket, mouseSocket);
            var factory = factoryMock.Object;

            var clientMock = new Mock<Client>(keyStore, factory, new NullLogger<Client>());

            clientMock.Setup(x => x.SendCommandAsync<HandshakeResponse>(It.IsAny<HandshakeCommand>())).ReturnsAsync(
                new HandshakeResponse
                {
                    ReturnValue = true,
                    Key = "abc123"
                });

            clientMock.Setup(x => x.SendCommandAsync<MouseGetResponse>(It.IsAny<MouseGetCommand>())).ReturnsAsync(
                new MouseGetResponse
                {
                    ReturnValue = true,
                    SocketPath = "ws://thehost:3000/mouse"
                });

            var client = clientMock.Object;

            await Assert.ThrowsAsync<ConnectionException>(async () => await client.ConnectAsync("thehost"));
            mouseSocketMock.Verify(x => x.Connect("ws://thehost:3000/mouse"), Times.Never);
        }

        [Fact]
        public async void ConnectAndCloseFailsMouseSocket()
        {
            var keyStoreMock = CreateKeyStore();
            var keyStore = keyStoreMock.Object;

            var mainSocketMock = CreateSocketConnection("ws://thehost:3000");
            var mainSocket = mainSocketMock.Object;

            var mouseSocketMock = CreateSocketConnection("ws://thehost:3000/mouse", false);
            var mouseSocket = mouseSocketMock.Object;

            var factoryMock = CreateFactory(mainSocket, mouseSocket);
            var factory = factoryMock.Object;

            var clientMock = new Mock<Client>(keyStore, factory, new NullLogger<Client>());

            clientMock.Setup(x => x.SendCommandAsync<HandshakeResponse>(It.IsAny<HandshakeCommand>())).ReturnsAsync(
                new HandshakeResponse
                {
                    ReturnValue = true,
                    Key = "abc123"
                });

            clientMock.Setup(x => x.SendCommandAsync<MouseGetResponse>(It.IsAny<MouseGetCommand>())).ReturnsAsync(
                new MouseGetResponse
                {
                    ReturnValue = true,
                    SocketPath = "ws://thehost:3000/mouse"
                });

            var client = clientMock.Object;

            await Assert.ThrowsAsync<ConnectionException>(async () => await client.ConnectAsync("thehost"));
            mouseSocketMock.Verify(x => x.Connect("ws://thehost:3000/mouse"), Times.Once);
        }

        [Fact]
        public async void SendCommandSuccessful()
        {
            var keyStoreMock = CreateKeyStore();
            var keyStore = keyStoreMock.Object;

            var mainSocketMock = CreateSocketConnection("ws://thehost:3000");
            var mainSocket = mainSocketMock.Object;

            var mouseSocketMock = CreateSocketConnection("ws://thehost:3000/mouse");
            var mouseSocket = mouseSocketMock.Object;

            var factoryMock = CreateFactory(mainSocket, mouseSocket);
            var factory = factoryMock.Object;

            var client = new Client(keyStore, factory, new NullLogger<Client>());
            client.SetSocketsForTesting(mainSocket, mouseSocket);

            var commandTask = client.SendCommandAsync<VolumeDownResponse>(new VolumeDownCommand {CustomId = "theid"});

            await Task.Delay(1000);

            var payload = JObject.Parse("{ \"returnValue\" : true }");
            var responseMessage = new Message
            {
                Id = "theid",
                Type = "response",
                Payload = payload
            };

            client.OnMessage(null, new SocketMessageEventArgs(JsonConvert.SerializeObject(responseMessage)));

            await commandTask;

            var response = commandTask.Result;
            Assert.True(response.ReturnValue);
        }

        [Fact]
        public async void SendCommandTimeout()
        {
            var keyStoreMock = CreateKeyStore();
            var keyStore = keyStoreMock.Object;

            var mainSocketMock = CreateSocketConnection("ws://thehost:3000");
            var mainSocket = mainSocketMock.Object;

            var mouseSocketMock = CreateSocketConnection("ws://thehost:3000/mouse");
            var mouseSocket = mouseSocketMock.Object;

            var factoryMock = CreateFactory(mainSocket, mouseSocket);
            var factory = factoryMock.Object;

            var client = new Client(keyStore, factory, new NullLogger<Client>())
            {
                CommandTimeout = 500
            };

            client.SetSocketsForTesting(mainSocket, mouseSocket);

            await Assert.ThrowsAsync<TimeoutException>(async () =>
                await client.SendCommandAsync<VolumeDownResponse>(new VolumeDownCommand {CustomId = "theid"}));
        }

        [Fact]
        public async void SendCommandError()
        {
            var keyStoreMock = CreateKeyStore();
            var keyStore = keyStoreMock.Object;

            var mainSocketMock = CreateSocketConnection("ws://thehost:3000");
            var mainSocket = mainSocketMock.Object;

            var mouseSocketMock = CreateSocketConnection("ws://thehost:3000/mouse");
            var mouseSocket = mouseSocketMock.Object;

            var factoryMock = CreateFactory(mainSocket, mouseSocket);
            var factory = factoryMock.Object;

            var client = new Client(keyStore, factory, new NullLogger<Client>());
            client.SetSocketsForTesting(mainSocket, mouseSocket);

            var commandTask = client.SendCommandAsync<VolumeDownResponse>(new VolumeDownCommand {CustomId = "theid"});

            await Task.Delay(1000);

            var responseMessage = new Message
            {
                Id = "theid",
                Type = "error",
                Error = "BOOM!"
            };

            client.OnMessage(null, new SocketMessageEventArgs(JsonConvert.SerializeObject(responseMessage)));

            var ex = await Assert.ThrowsAsync<AggregateException>(async () => await commandTask);
            Assert.Equal(typeof(CommandException), ex.InnerException?.GetType());
        }

        [Fact]
        public async void SendButtonSuccessful()
        {
            var keyStoreMock = CreateKeyStore();
            var keyStore = keyStoreMock.Object;

            var mainSocketMock = CreateSocketConnection("ws://thehost:3000");
            var mainSocket = mainSocketMock.Object;

            var mouseSocketMock = CreateSocketConnection("ws://thehost:3000/mouse");
            var mouseSocket = mouseSocketMock.Object;

            var factoryMock = CreateFactory(mainSocket, mouseSocket);
            var factory = factoryMock.Object;

            var client = new Client(keyStore, factory, new NullLogger<Client>());
            client.SetSocketsForTesting(mainSocket, mouseSocket);

            await client.SendButtonAsync(ButtonTypes.Back);

            mouseSocketMock.Verify(x => x.Send(It.IsAny<string>()));
        }

        private Mock<IKeyStore> CreateKeyStore()
        {
            var mock = new Mock<IKeyStore>();
            mock.Setup(x => x.GetKeyAsync("thehost")).ReturnsAsync("abc123").Verifiable();
            mock.Setup(x => x.StoreKeyAsync("thehost", "abc123")).Verifiable();
            return mock;
        }

        private Mock<ISocketConnection> CreateSocketConnection(string url, bool alive = true)
        {
            var mock = new Mock<ISocketConnection>();
            mock.Setup(x => x.IsAlive).Returns(alive);
            mock.Setup(x => x.Connect(url)).Verifiable();
            mock.Setup(x => x.Send(It.IsAny<string>())).Verifiable();
            mock.Setup(x => x.Close()).Verifiable();
            return mock;
        }

        private Mock<IFactory<ISocketConnection>> CreateFactory(ISocketConnection main, ISocketConnection mouse)
        {
            var mock = new Mock<IFactory<ISocketConnection>>();
            mock.SetupSequence(x => x.Create())
                .Returns(main)
                .Returns(mouse);

            return mock;
        }
    }
}
