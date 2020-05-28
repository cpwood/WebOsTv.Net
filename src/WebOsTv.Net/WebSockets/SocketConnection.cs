using System;
using WebSocketSharp;

namespace WebOsTv.Net.WebSockets
{
    internal class SocketConnection : ISocketConnection
    {
        private WebSocket _socket;

        public string Url { get; private set; }

        public void Connect(string url)
        {
            Url = url;

            _socket = new WebSocket(url);
            _socket.OnMessage += (sender, args) => OnMessage?.Invoke(sender, new SocketMessageEventArgs(args.Data));
            _socket.Connect();
        }

        public bool IsAlive => _socket.IsAlive;

        public event EventHandler<SocketMessageEventArgs> OnMessage;

        public void Send(string content)
        {
            _socket?.Send(content);
        }

        public void Close()
        {
            _socket?.Close();
        }
    }
}
