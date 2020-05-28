namespace WebOsTv.Net.Commands.Audio
{
    public class VolumeDownCommand : NoPayloadCommandBase
    {
        public override string Uri => "ssap://audio/volumeDown";
    }
}
