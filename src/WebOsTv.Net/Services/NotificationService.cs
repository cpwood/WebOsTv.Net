using System.Threading.Tasks;
using WebOsTv.Net.Commands.Notifications;
using WebOsTv.Net.Responses.Notifications;

namespace WebOsTv.Net.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IClient _client;

        internal NotificationService(IClient client)
        {
            _client = client;
        }

        public async Task SendToastAsync(string message)
        {
            await _client.SendCommandAsync<ToastResponse>(new ToastCommand { Message = message});
        }

    }
}