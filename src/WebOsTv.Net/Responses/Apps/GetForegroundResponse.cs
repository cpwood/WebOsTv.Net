namespace WebOsTv.Net.Responses.Apps
{
    public class GetForegroundResponse : ResponseBase
    {
        public string AppId { get; set; }
        public string WindowId { get; set; }
        public string ProcessId { get; set; }
    }
}
