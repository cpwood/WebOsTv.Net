using Newtonsoft.Json;

namespace WebOsTv.Net.Responses.Api
{
    public class HandshakeResponse : ResponseBase
    {
        [JsonProperty("client-key")]
        public string Key { get; set; }

        public HandshakeResponse()
        {
            ReturnValue = true;
        }
    }
}
