namespace WebOsTv.Net.Commands.Audio
{
    public class VolumeGetCommand : NoPayloadCommandBase
    {
        public override string Uri => "ssap://audio/getVolume";
    }
}
