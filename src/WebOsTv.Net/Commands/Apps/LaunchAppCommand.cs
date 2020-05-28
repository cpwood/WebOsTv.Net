namespace WebOsTv.Net.Commands.Apps
{
    public class LaunchAppCommand : CommandBase
    {
        public override string Uri => "ssap://system.launcher/launch";

        public string Id { get; set; }
    }
}
