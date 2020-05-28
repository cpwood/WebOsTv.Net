namespace WebOsTv.Net.Commands.Audio
{
    public class VolumeSetCommand : CommandBase
    {
        public override string Uri => "ssap://audio/setVolume";

        public int Volume { get; set; }
    }
}
