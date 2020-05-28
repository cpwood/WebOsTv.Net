namespace WebOsTv.Net.Commands.Apps
{
    public class OpenAppCommand : CommandBase
    {
        public override string Uri => "ssap://system.launcher/open";

        public string Id {get; set; }
    }
}
