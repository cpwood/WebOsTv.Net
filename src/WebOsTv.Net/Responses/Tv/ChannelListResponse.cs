namespace WebOsTv.Net.Responses.Tv
{
    public class ChannelListResponse : ResponseBase
    {
        public string ValueList { get; set; }
        public int DataSource { get; set; }
        public int DataType { get; set; }
        public bool CableAnalogSkipped { get; set; }
        public ScannedChannels ScannedChannelCount { get; set; }
        public int DeviceSourceIndex { get; set; }
        public int ChannelListCount { get; set; }
        public string ChannelLogoServerUrl { get; set; }
        public string IpChanInteractiveUrl { get; set; }
        public Channel[] ChannelList { get; set; }

        public class ScannedChannels
        {
            public int TerrestrialAnalogCount { get; set; }
            public int TerrestrialDigitalCount { get; set; }
            public int CableAnalogCount { get; set; }
            public int CableDigitalCount { get; set; }
            public int SatelliteDigitalCount { get; set; }
        }

        public class Channel
        {
            public string ChannelId { get; set; }
            public string ProgramId { get; set; }
            public string SignalChannelId { get; set; }
            public string ChanCode { get; set; }
            public string ChannelMode { get; set; }
            public int ChannelModeId { get; set; }
            public string ChannelType { get; set; }
            public int ChannelTypeId { get; set; }
            public string ChannelNumber { get; set; }
            public int MajorNumber { get; set; }
            public int MinorNumber { get; set; }
            public string ChannelName { get; set; }
            public bool Skipped { get; set; }
            public bool Locked { get; set; }
            public bool Descrambled { get; set; }
            public bool Scrambled { get; set; }
            public int ServiceType { get; set; }
            public string[] FavoriteGroup { get; set; }
            public string ImgUrl { get; set; }
            public int Display { get; set; }
            public string SatelliteName { get; set; }
            public bool FineTuned { get; set; }
            public int Frequency { get; set; }
            public int ShortCut { get; set; }
            public int Bandwidth { get; set; }
            public bool HDTV { get; set; }
            public bool Invisible { get; set; }
            public bool TV { get; set; }
            public bool DTV { get; set; }
            public bool ATV { get; set; }
            public bool Data { get; set; }
            public bool Radio { get; set; }
            public bool Numeric { get; set; }
            public bool PrimaryCh { get; set; }
            public bool SpecialService { get; set; }
            public Casystemidlist CASystemIDList { get; set; }
            public int CASystemIDListCount { get; set; }
            public int[] GroupIdList { get; set; }
            public string ChannelGenreCode { get; set; }
            public int FavoriteIdxA { get; set; }
            public int FavoriteIdxB { get; set; }
            public int FavoriteIdxC { get; set; }
            public int FavoriteIdxD { get; set; }
            public string ImgUrl2 { get; set; }
            public string ChannelLogoSize { get; set; }
            public string IpChanServerUrl { get; set; }
            public bool PayChan { get; set; }
            public string IPChannelCode { get; set; }
            public string IpCallNumber { get; set; }
            public bool OtuFlag { get; set; }
            public int FavoriteIdxE { get; set; }
            public int FavoriteIdxF { get; set; }
            public int FavoriteIdxG { get; set; }
            public int FavoriteIdxH { get; set; }
            public bool SatelliteLcn { get; set; }
            public string WaterMarkUrl { get; set; }
            public string ChannelNameSortKey { get; set; }
            public string IpChanType { get; set; }
            public int AdultFlag { get; set; }
            public string IpChanCategory { get; set; }
            public bool IpChanInteractive { get; set; }
            public string CallSign { get; set; }
            public int AdFlag { get; set; }
            public bool Configured { get; set; }
            public string LastUpdated { get; set; }
            public string IpChanCpId { get; set; }
            public int IsFreeviewPlay { get; set; }
            public int HasBackward { get; set; }
            public string PlayerService { get; set; }
            public int TSID { get; set; }
            public int SVCID { get; set; }
        }

        public class Casystemidlist
        {
        }

    }
}
