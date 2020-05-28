namespace WebOsTv.Net.Commands.Media
{
    public class ControlStopCommand : NoPayloadCommandBase
    {
        public override string Uri => "ssap://media.controls/stop";
    }
}
