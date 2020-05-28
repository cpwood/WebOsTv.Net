namespace WebOsTv.Net.Responses.Tv
{
    public class ExternalInputListResponse : ResponseBase
    {
        public Device[] Devices { get; set; }

        public class Device
        {
            public string Id { get; set; }
            public string Label { get; set; }
            public int Port { get; set; }
            public bool Connected { get; set; }
            public string AppId { get; set; }
            public string Icon { get; set; }
            public bool Modified { get; set; }
            public Sublist[] SubList { get; set; }
            public int SubCount { get; set; }
            public bool Favorite { get; set; }
            public int LastUniqueId { get; set; }
            public bool HdmiPlugIn { get; set; }
            public bool DongleConnected { get; set; }
        }

        public class Sublist
        {
            public string Id { get; set; }
            public string ServiceType { get; set; }
            public string ConnectedInput { get; set; }
            public string ServiceName { get; set; }
            public string SettopCode { get; set; }
            public string SettopOption { get; set; }
            public string BrandName { get; set; }
            public string LabelName { get; set; }
            public string Codeset { get; set; }
            public string OssSetupStatus { get; set; }
            public string DetectedMethod { get; set; }
            public string ServiceArea { get; set; }
            public bool IsMainSTB { get; set; }
        }

    }
}
