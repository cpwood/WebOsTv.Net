using System.Threading.Tasks;

namespace WebOsTv.Net.Services
{
    public interface INotificationService
    {
        Task SendToastAsync(string message);
    }
}