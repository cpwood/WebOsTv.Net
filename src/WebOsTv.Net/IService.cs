using System.Threading.Tasks;
using WebOsTv.Net.Services;

namespace WebOsTv.Net
{
    public interface IService
    {
        IApiService Api { get; }
        IAppsService Apps { get; }
        IAudioService Audio { get; }
        IControlService Control { get; }
        INotificationService Notifications { get; }
        ITvService Tv { get; }
        Task ConnectAsync(string hostName);
        void Close();
    }
}