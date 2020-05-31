using System.Threading.Tasks;
using WebOsTv.Net.Responses.Apps;

namespace WebOsTv.Net.Services
{
    public interface IAppsService
    {
        Task CloseAsync(string appId);
        Task<string> GetCurrentAsync();
        Task LaunchAsync(string appId);
        Task LaunchBrowserAsync(string url);
        Task LaunchYouTubeVideoAsync(string videoId);
        Task<ListLaunchPointsResponse.LaunchPoint[]> ListAsync();
    }
}