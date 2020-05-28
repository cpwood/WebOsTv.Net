namespace WebOsTv.Net.Responses.Api
{
    public class ServiceListResponse : ResponseBase
    {
        public ServiceItem[] Services { get; set; }

        public class ServiceItem
        {
            public string Name { get; set; }
            public int Version { get; set; }
        }
    }
}
