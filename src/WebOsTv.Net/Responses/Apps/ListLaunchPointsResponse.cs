namespace WebOsTv.Net.Responses.Apps
{
    public class ListLaunchPointsResponse : ResponseBase
    {
        public bool Subscribed { get; set; }
        public Case CaseDetail { get; set; }
        public LaunchPoint[] LaunchPoints { get; set; }

        public class Case
        {
            public object[] Change { get; set; }
        }

        public class LaunchPoint
        {
            public bool SystemApp { get; set; }
            public bool Removable { get; set; }
            public Preview PreviewMetadata { get; set; }
            public string[] Icons { get; set; }
            public string MediumLargeIcon { get; set; }
            public string LargeIcon { get; set; }
            public string[] BgImages { get; set; }
            public string UserData { get; set; }
            public bool Relaunch { get; set; }
            public string Id { get; set; }
            public string BgColor { get; set; }
            public string Title { get; set; }
            public string IconColor { get; set; }
            public string AppDescription { get; set; }
            public string Lptype { get; set; }
            public object Params { get; set; }
            public string BgImage { get; set; }
            public bool Unmovable { get; set; }
            public string Miniicon { get; set; }
            public string Icon { get; set; }
            public string LaunchPointId { get; set; }
            public string Favicon { get; set; }
            public int InstallTime { get; set; }
            public string ImageForRecents { get; set; }
            public string TileSize { get; set; }
        }


        public class Preview
        {
            public string SourceEndpoint { get; set; }
            public string TargetEndpoint { get; set; }
        }

    }
}
