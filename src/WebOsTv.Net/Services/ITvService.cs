using System.Threading.Tasks;
using WebOsTv.Net.Responses.Tv;

namespace WebOsTv.Net.Services
{
    public interface ITvService
    {
        Task ChannelDownAsync();
        Task<ChannelListResponse.Channel[]> ListChannelsAsync();
        Task ChannelUpAsync();
        Task<ExternalInputListResponse.Device[]> ListInputsAsync();
        Task<GetChannelProgramInfoResponse.ProgramItem[]> GetProgramInfoAsync();
        Task<string> GetCurrentChannelAsync();
        Task SetInputAsync(string inputId);
        Task TurnOn3dAsync();
        Task TurnOff3dAsync();
        Task<ThreeDimensionStatusResponse.Status3d> Get3dStatusAsync();
    }
}