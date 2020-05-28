namespace WebOsTv.Net.Commands.Media
{
    public class ControlPauseCommand : NoPayloadCommandBase
    {
        public override string Uri => "ssap://media.controls/pause";
    }
}
