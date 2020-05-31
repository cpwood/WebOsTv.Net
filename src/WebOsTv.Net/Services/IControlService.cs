using System.Threading.Tasks;

namespace WebOsTv.Net.Services
{
    public interface IControlService
    {
        Task SendIntentAsync(ControlService.ControlIntent intent);
    }
}