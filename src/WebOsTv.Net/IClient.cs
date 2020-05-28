using System.Threading.Tasks;
using WebOsTv.Net.Commands;
using WebOsTv.Net.Commands.Tv;
using WebOsTv.Net.Responses;

namespace WebOsTv.Net
{
    public interface IClient
    {
        Task ConnectAsync(string hostName);
        Task<TResponse> SendCommandAsync<TResponse>(CommandBase command) where TResponse : ResponseBase;
        Task SendButtonAsync(ButtonTypes type);
        void Close();
    }
}