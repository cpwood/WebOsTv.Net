using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebOsTv.Net.FileSystem;

namespace WebOsTv.Net.Auth
{
    public class KeyStore : IKeyStore
    {
        private readonly IFileService _fileService;
        private readonly Dictionary<string, string> _keys = new Dictionary<string, string>();

        public KeyStore(IFileService fileService)
        {
            _fileService = fileService;

            if (_fileService.Exists("lgkeys.json"))
                _keys = JsonConvert.DeserializeObject<Dictionary<string, string>>(_fileService.ReadAllText("lgkeys.json"));
        }

        public Task StoreKeyAsync(string hostName, string key)
        {
            if (_keys.ContainsKey(hostName))
                _keys.Remove(hostName);

            _keys.Add(hostName, key);

            _fileService.WriteAllText("lgkeys.json", JsonConvert.SerializeObject(_keys));

            return Task.CompletedTask;
        }

        public Task<string> GetKeyAsync(string hostName)
        {
            return Task.FromResult(_keys.ContainsKey(hostName) ? _keys[hostName] : null);
        }
    }
}
