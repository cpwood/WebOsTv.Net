namespace WebOsTv.Net.Commands.Tv
{
    public class ThreeDimensionOnCommand : NoPayloadCommandBase
    {
        public override string Uri => "ssap://com.webos.service.tv.display/set3DOn";
    }
}
