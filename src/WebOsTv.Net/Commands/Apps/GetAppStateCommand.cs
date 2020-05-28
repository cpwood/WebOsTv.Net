namespace WebOsTv.Net.Commands.Apps
{
    public class GetAppStateCommand : CommandBase
    {
        public override string Uri => "ssap://system.launcher/getAppState";

        public string Id { get; set; }
    }
}
