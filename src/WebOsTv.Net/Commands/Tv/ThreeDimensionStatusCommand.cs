namespace WebOsTv.Net.Commands.Tv
{
    public class ThreeDimensionStatusCommand : NoPayloadCommandBase
    {
        public override string Uri => "ssap://com.webos.service.tv.display/get3DStatus";
    }
}
