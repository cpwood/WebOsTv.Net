using System.Threading.Tasks;
using WebOsTv.Net.Responses.Api;

namespace WebOsTv.Net.Services
{
    public interface IApiService
    {
        Task<ServiceListResponse.ServiceItem[]> ListServicesAsync();
    }
}