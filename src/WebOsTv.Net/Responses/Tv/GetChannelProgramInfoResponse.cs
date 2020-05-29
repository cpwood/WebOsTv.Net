using Newtonsoft.Json;

namespace WebOsTv.Net.Responses.Tv
{
    public class GetChannelProgramInfoResponse : ResponseBase
    {
        public ChannelInfo Channel { get; set; }
        public ProgramItem[] ProgramList { get; set; }

        public class ChannelInfo
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
            public bool Tv { get; set; }
            public bool DTV { get; set; }
            public bool ATV { get; set; }
            public bool Data { get; set; }
            public bool Radio { get; set; }
            public bool Numeric { get; set; }
            public bool PrimaryCh { get; set; }
            public bool SpecialService { get; set; }
            public CaSystemId CASystemIDList { get; set; }
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
            public string IpChannelCode { get; set; }
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

        public class CaSystemId
        {
        }

        public class ProgramItem
        {
            public string ChannelId { get; set; }
            public int Duration { get; set; }
            public string EndTime { get; set; }
            public string LocalEndTime { get; set; }
            public string LocalStartTime { get; set; }
            public string Genre { get; set; }
            public string ProgramId { get; set; }
            public string ProgramName { get; set; }
            public Rating[] Rating { get; set; }
            public string SignalChannelId { get; set; }
            public string StartTime { get; set; }
            public int TableId { get; set; }
        }

        public class Rating
        {
            public string RatingString { get; set; }
            public int RatingValue { get; set; }
            public int Region { get; set; }

            [JsonProperty("_id")]
            public string Id { get; set; }
        }

    }
}
