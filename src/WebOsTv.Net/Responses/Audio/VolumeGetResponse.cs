namespace WebOsTv.Net.Responses.Audio
{
    public class VolumeGetResponse : ResponseBase
    {
        public string Scenario { get; set; }
        public int Volume { get; set; }
        public bool Muted { get; set; }
    }
}
