using System.Threading.Tasks;
using WebOsTv.Net.Commands.Tv;
using WebOsTv.Net.Responses.Tv;

namespace WebOsTv.Net.Services
{
    public class TvService : ITvService
    {
        private readonly IClient _client;

        internal TvService(IClient client)
        {
            _client = client;
        }

        public async Task ChannelDownAsync()
        {
            await _client.SendCommandAsync<ChannelDownResponse>(new ChannelDownCommand());
        }

        public async Task<ChannelListResponse.Channel[]> ListChannelsAsync()
        {
            var response = await _client.SendCommandAsync<ChannelListResponse>(new ChannelListCommand());
            return response.ChannelList;
        }

        public async Task ChannelUpAsync()
        {
            await _client.SendCommandAsync<ChannelUpResponse>(new ChannelUpCommand());
        }

        public async Task<ExternalInputListResponse.Device[]> ListInputsAsync()
        {
            var response = await _client.SendCommandAsync<ExternalInputListResponse>(new ExternalInputListCommand());
            return response.Devices;
        }

        public async Task<GetChannelProgramInfoResponse.ProgramItem[]> GetProgramInfoAsync()
        {
            var response = await _client.SendCommandAsync<GetChannelProgramInfoResponse>(new GetChannelProgramInfoCommand());
            return response.ProgramList;
        }

        public async Task<string> GetCurrentChannelAsync()
        {
            var response = await _client.SendCommandAsync<GetCurrentChannelResponse>(new GetCurrentChannelCommand());
            return response.ChannelId;
        }

        public async Task SetInputAsync(string inputId)
        {
            await _client.SendCommandAsync<SwitchInputResponse>(new SwitchInputCommand{ InputId = inputId});
        }

        public async Task TurnOn3dAsync()
        {
            await _client.SendCommandAsync<ThreeDimensionOnResponse>(new ThreeDimensionOnCommand());
        }

        public async Task TurnOff3dAsync()
        {
            await _client.SendCommandAsync<ThreeDimensionOffResponse>(new ThreeDimensionOffCommand());
        }

        public async Task<ThreeDimensionStatusResponse.Status3d> Get3dStatusAsync()
        {
            var response = await _client.SendCommandAsync<ThreeDimensionStatusResponse>(new ThreeDimensionStatusCommand());
            return response.Status3D;
        }
    }
}