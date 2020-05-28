namespace WebOsTv.Net.Commands.Tv
{
    public class ChannelDownCommand : NoPayloadCommandBase
    {
        public override string Uri => "ssap://tv/channelDown";
    }
}
