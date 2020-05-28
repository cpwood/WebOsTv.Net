using System;

namespace WebOsTv.Net.Exceptions
{
    public class CommandException : Exception
    {
        public CommandException(string error) : base(error){}
    }
}
