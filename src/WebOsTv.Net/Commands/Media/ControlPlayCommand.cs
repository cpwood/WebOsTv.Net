namespace WebOsTv.Net.Commands.Media
{
    public class ControlPlayCommand : NoPayloadCommandBase
    {
        public override string Uri => "ssap://media.controls/play";
    }
}
