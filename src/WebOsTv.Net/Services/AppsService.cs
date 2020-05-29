using System.Threading.Tasks;
using WebOsTv.Net.Commands.Apps;
using WebOsTv.Net.Responses.Apps;

namespace WebOsTv.Net.Services
{
    public class AppsService
    {
        private readonly IClient _client;

        internal AppsService(IClient client)
        {
            _client = client;
        }

        public async Task CloseAsync(string appId)
        {
            await _client.SendCommandAsync<CloseCommandResponse>(new CloseCommand {Id = appId});
        }

        public async Task<string> GetCurrentAsync()
        {
            var response = await _client.SendCommandAsync<GetForegroundResponse>(new GetForegroundCommand());
            return response.AppId;
        }

        public async Task LaunchAsync(string appId)
        {
            await _client.SendCommandAsync<LaunchAppResponse>(new LaunchAppCommand { Id = appId});
        }

        public async Task LaunchBrowserAsync(string url)
        {
            await _client.SendCommandAsync<LaunchBrowserResponse>(new LaunchBrowserCommand { BrowserUrl = url});
        }

        public async Task LaunchYouTubeVideoAsync(string videoId)
        {
            await _client.SendCommandAsync<LaunchYouTubeVideoResponse>(new LaunchYouTubeVideoCommand { VideoId = videoId});
        }

        public async Task<ListLaunchPointsResponse.LaunchPoint[]> ListAsync()
        {
            var response = await _client.SendCommandAsync<ListLaunchPointsResponse>(new ListLaunchPointsCommand());
            return response.LaunchPoints;
        }
    }
}