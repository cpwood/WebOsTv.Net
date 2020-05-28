namespace WebOsTv.Net.Commands.Audio
{
    public class VolumeUpCommand : NoPayloadCommandBase
    {
        public override string Uri => "ssap://audio/volumeUp";
    }
}