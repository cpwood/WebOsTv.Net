using Newtonsoft.Json.Linq;

namespace WebOsTv.Net.Commands
{
    public abstract class NoPayloadCommandBase : CommandBase
    {
        public override JObject ToJObject()
        {
            return null;
        }
    }
}
