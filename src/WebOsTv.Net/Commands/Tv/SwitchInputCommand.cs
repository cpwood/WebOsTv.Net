namespace WebOsTv.Net.Commands.Tv
{
    public class SwitchInputCommand : CommandBase
    {
        public override string Uri => "ssap://tv/switchInput";

        public string InputId { get; set; }
    }
}
