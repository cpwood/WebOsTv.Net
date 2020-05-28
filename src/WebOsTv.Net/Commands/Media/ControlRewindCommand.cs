namespace WebOsTv.Net.Commands.Media
{
    public class ControlRewindCommand : NoPayloadCommandBase
    {
        public override string Uri => "ssap://media.controls/rewind";
    }
}
