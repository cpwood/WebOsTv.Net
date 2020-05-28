namespace WebOsTv.Net.Commands.Tv
{
    public class ExternalInputListCommand : NoPayloadCommandBase
    {
        public override string Uri => "ssap://tv/getExternalInputList";
    }
}
