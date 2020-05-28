using System;

namespace WebOsTv.Net.Exceptions
{
    public class ConnectionException : Exception
    {
        public ConnectionException(string message) : base(message){}
    }
}
