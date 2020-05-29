using System.Threading.Tasks;
using WebOsTv.Net.Commands.Media;
using WebOsTv.Net.Commands.System;
using WebOsTv.Net.Responses.Media;
using WebOsTv.Net.Responses.System;

namespace WebOsTv.Net.Services
{
    public class ControlService
    {
        private readonly IClient _client;

        internal ControlService(IClient client)
        {
            _client = client;
        }

        public async Task FastForwardAsync()
        {
            await _client.SendCommandAsync<ControlFastForwardResponse>(new ControlFastForwardCommand());
        }

        public async Task PauseAsync()
        {
            await _client.SendCommandAsync<ControlPauseResponse>(new ControlPauseCommand());
        }

        public async Task PlayAsync()
        {
            await _client.SendCommandAsync<ControlPlayResponse>(new ControlPlayCommand());
        }

        public async Task RewindAsync()
        {
            await _client.SendCommandAsync<ControlRewindResponse>(new ControlRewindCommand());
        }

        public async Task StopAsync()
        {
            await _client.SendCommandAsync<ControlStopResponse>(new ControlStopCommand());
        }

        public async Task PowerOffAsync()
        {
            await _client.SendCommandAsync<PowerOffResponse>(new PowerOffCommand());
        }
    }
}