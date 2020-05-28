using Newtonsoft.Json;

namespace WebOsTv.Net.Commands.Apps
{
    public class LaunchYouTubeVideoCommand : CommandBase
    {
        private string _videoId;

        public override string Uri => "ssap://system.launcher/launch";

        [JsonProperty] 
        internal string Id => "youtube.leanback.v4";

        [JsonIgnore]
        public string VideoId
        {
            get => _videoId;
            set
            {
                _videoId = value;
                Parameters.ContentTarget = $"https://www.youtube.com/tv?v={value}";
            } 
        }

        [JsonProperty("params")]
        internal YouTubeParameter Parameters { get; } = new YouTubeParameter();


        internal class YouTubeParameter
        {
            public string ContentTarget { get; set; }
        }
    }
}
