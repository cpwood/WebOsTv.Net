using System;
using WebSocketSharp;

namespace WebOsTv.Net.WebSockets
{
    internal interface ISocketConnection
    {
        string Url { get; }
        void Connect(string url);
        bool IsAlive { get; }
        event EventHandler<SocketMessageEventArgs> OnMessage;
        void Send(string content);
        void Close();
    }
}