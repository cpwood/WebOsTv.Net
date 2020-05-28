namespace WebOsTv.Net.Commands.Api
{
    public class MouseGetCommand : CommandBase
    {
        public override string Uri => "ssap://com.webos.service.networkinput/getPointerInputSocket";
    }
}
