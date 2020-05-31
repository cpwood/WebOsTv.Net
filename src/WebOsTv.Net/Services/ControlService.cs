using System;
using System.Threading.Tasks;
using WebOsTv.Net.Commands.Media;
using WebOsTv.Net.Commands.System;
using WebOsTv.Net.Commands.Tv;
using WebOsTv.Net.Responses.Media;
using WebOsTv.Net.Responses.System;

namespace WebOsTv.Net.Services
{
    public class ControlService : IControlService
    {
        private readonly IClient _client;

        public enum ControlIntent
        {
            // Button Presses
            Home,
            Back,
            Up,
            Down,
            Left,
            Right,
            Red,
            Blue,
            Yellow,
            Green,

            // Other Commands
            FastForward,
            Pause,
            Play,
            Rewind,
            Stop,
            PowerOff
        }

        internal ControlService(IClient client)
        {
            _client = client;
        }

        public async Task SendIntentAsync(ControlIntent intent)
        {
            switch (intent)
            {
                case ControlIntent.Home:
                case ControlIntent.Back:
                case ControlIntent.Up:
                case ControlIntent.Down:
                case ControlIntent.Left:
                case ControlIntent.Right:
                case ControlIntent.Red:
                case ControlIntent.Blue:
                case ControlIntent.Yellow:
                case ControlIntent.Green:
                    await _client.SendButtonAsync((ButtonTypes) Enum.Parse(typeof(ButtonTypes), intent.ToString()));
                    break;
                case ControlIntent.FastForward:
                    await _client.SendCommandAsync<ControlFastForwardResponse>(new ControlFastForwardCommand());
                    break;
                case ControlIntent.Pause:
                    await _client.SendCommandAsync<ControlPauseResponse>(new ControlPauseCommand());
                    break;
                case ControlIntent.Play:
                    await _client.SendCommandAsync<ControlPlayResponse>(new ControlPlayCommand());
                    break;
                case ControlIntent.Rewind:
                    await _client.SendCommandAsync<ControlRewindResponse>(new ControlRewindCommand());
                    break;
                case ControlIntent.Stop:
                    await _client.SendCommandAsync<ControlStopResponse>(new ControlStopCommand());
                    break;
                case ControlIntent.PowerOff:
                    await _client.SendCommandAsync<PowerOffResponse>(new PowerOffCommand());
                    break;
            }
        }
    }
}