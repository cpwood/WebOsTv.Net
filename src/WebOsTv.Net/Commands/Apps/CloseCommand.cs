namespace WebOsTv.Net.Commands.Apps
{
    public class CloseCommand : CommandBase
    {
        public override string Uri => "ssap://system.launcher/close";

        public string Id { get; set; }
    }
}
