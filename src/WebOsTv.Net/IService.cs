using System.Threading.Tasks;
using WebOsTv.Net.Services;

namespace WebOsTv.Net
{
    public interface IService
    {
        ApiService Api { get; }
        AppsService Apps { get; }
        AudioService Audio { get; }
        ControlService Control { get; }
        NotificationService Notifications { get; }
        TvService Tv { get; }
        Task ConnectAsync(string hostName);
        void Close();
    }
}