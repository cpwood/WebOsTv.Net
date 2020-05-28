using System.Threading.Tasks;

namespace WebOsTv.Net.Auth
{
    public interface IKeyStore
    {
        Task StoreKeyAsync(string hostName, string key);
        Task<string> GetKeyAsync(string hostName);
    }
}
