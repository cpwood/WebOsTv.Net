namespace WebOsTv.Net.Commands.System
{
    public class PowerOffCommand : NoPayloadCommandBase
    {
        public override string Uri => "ssap://system/turnOff";
    }
}
