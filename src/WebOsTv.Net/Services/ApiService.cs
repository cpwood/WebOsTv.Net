using System.Threading.Tasks;
using WebOsTv.Net.Commands.Api;
using WebOsTv.Net.Responses.Api;

namespace WebOsTv.Net.Services
{
    public class ApiService : IApiService
    {
        private readonly IClient _client;

        internal ApiService(IClient client)
        {
            _client = client;
        }

        public async Task<ServiceListResponse.ServiceItem[]> ListServicesAsync()
        {
            var response = await _client.SendCommandAsync<ServiceListResponse>(new ServiceListGetCommand());
            return response.Services;
        }
    }
}
