namespace WebOsTv.Net.Commands.Tv
{
    public class GetCurrentChannelCommand : NoPayloadCommandBase
    {
        public override string Uri => "ssap://tv/getCurrentChannel";
    }
}
