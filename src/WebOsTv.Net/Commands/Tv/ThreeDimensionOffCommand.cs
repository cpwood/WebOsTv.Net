namespace WebOsTv.Net.Commands.Tv
{
    public class ThreeDimensionOffCommand : NoPayloadCommandBase
    {
        public override string Uri => "ssap://com.webos.service.tv.display/set3DOff";
    }
}