namespace WebOsTv.Net.Responses.Tv
{
    public class GetCurrentChannelResponse : ResponseBase
    {
        public string ChannelId { get; set; }
        public int PhysicalNumber { get; set; }
        public bool IsScrambled { get; set; }
        public string ChannelTypeName { get; set; }
        public bool IsLocked { get; set; }
        public Dualchannel DualChannel { get; set; }
        public bool IsChannelChanged { get; set; }
        public string ChannelModeName { get; set; }
        public string ChannelNumber { get; set; }
        public bool IsFineTuned { get; set; }
        public int ChannelTypeId { get; set; }
        public bool IsDescrambled { get; set; }
        public bool IsReplaceChannel { get; set; }
        public bool IsSkipped { get; set; }
        public bool IsHEVCChannel { get; set; }
        public object HybridtvType { get; set; }
        public bool IsInvisible { get; set; }
        public string FavoriteGroup { get; set; }
        public string ChannelName { get; set; }
        public int ChannelModeId { get; set; }
        public string SignalChannelId { get; set; }
        
        public class Dualchannel
        {
            public object DualChannelId { get; set; }
            public object DualChannelTypeName { get; set; }
            public object DualChannelTypeId { get; set; }
            public object DualChannelNumber { get; set; }
        }
    }
}
