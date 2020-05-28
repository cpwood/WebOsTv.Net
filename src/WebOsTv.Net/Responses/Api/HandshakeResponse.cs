using Newtonsoft.Json;

namespace WebOsTv.Net.Responses.Api
{
    public class HandshakeResponse : ResponseBase
    {
        [JsonProperty("client-key")]
        public string ClientKey { get; set; }

        public HandshakeResponse()
        {
            ReturnValue = true;
        }
    }
}
