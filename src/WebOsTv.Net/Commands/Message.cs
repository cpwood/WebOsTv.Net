using System;
using Newtonsoft.Json.Linq;

namespace WebOsTv.Net.Commands
{
    internal class Message
    {
        public string Id { get; set; } = GenerateId();
        public string Type { get; set; }
        public string Uri { get; set; }
        public JObject Payload { get; set; }
        public string Error { get; set; }

        internal static string GenerateId()
        {
            return Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}
