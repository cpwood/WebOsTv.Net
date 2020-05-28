using Newtonsoft.Json.Linq;
using System.IO;
using WebOsTv.Net.Auth;
using WebOsTv.Net.Commands.Api;
using WebOsTv.Net.Commands.Apps;
using WebOsTv.Net.Commands.Audio;
using WebOsTv.Net.Commands.Media;
using WebOsTv.Net.Commands.Notifications;
using WebOsTv.Net.Commands.System;
using WebOsTv.Net.Commands.Tv;
using WebOsTv.Net.FileSystem;
using WebOsTv.Net.Responses.Api;
using WebOsTv.Net.Responses.Apps;
using WebOsTv.Net.Responses.Audio;
using WebOsTv.Net.Responses.Media;
using WebOsTv.Net.Responses.Notifications;
using WebOsTv.Net.Responses.System;
using WebOsTv.Net.Responses.Tv;
using Xunit.Abstractions;

namespace WebOsTv.Net.Tests
{
    public class IntegrationTests
    {
        private readonly Client _client;

        public IntegrationTests(ITestOutputHelper output)
        {
            var logger = output.BuildLoggerFor<Client>();

            var obj = JObject.Parse(File.ReadAllText("..\\..\\..\\device.json"));
            var ipAddress = obj["IpAddress"].Value<string>();

            _client = new Client(new KeyStore(new FileService()), logger) {CommandTimeout = 60000};
            _client.ConnectAsync(ipAddress).Wait();
        }

        #region Audio
        [DebugOnly]
        public async void TestPowerOff()
        {
            var unused = await _client.SendCommandAsync<PowerOffResponse>(new PowerOffCommand());
        }

        [DebugOnly]
        public async void TestVolumeGet()
        {
            var unused = await _client.SendCommandAsync<VolumeGetResponse>(new VolumeGetCommand());
        }

        [DebugOnly]
        public async void TestVolumeSet()
        {
            var unused = await _client.SendCommandAsync<VolumeSetResponse>(new VolumeSetCommand { Volume = 0 });
        }

        [DebugOnly]
        public async void TestVolumeUp()
        {
            var unused = await _client.SendCommandAsync<VolumeUpResponse>(new VolumeUpCommand());
        }

        [DebugOnly]
        public async void TestVolumeDown()
        {
            var unused = await _client.SendCommandAsync<VolumeDownResponse>(new VolumeDownCommand());
        }

        [DebugOnly]
        public async void TestMute()
        {
            var unused = await _client.SendCommandAsync<VolumeMuteResponse>(new VolumeMuteCommand { Mute = true });
        }

        [DebugOnly]
        public async void TestUnmute()
        {
            var unused = await _client.SendCommandAsync<VolumeMuteResponse>(new VolumeMuteCommand { Mute = false });
        }
        #endregion

        #region Media
        [DebugOnly]
        public async void TestFastForward()
        {
            var unused = await _client.SendCommandAsync<ControlFastForwardResponse>(new ControlFastForwardCommand());
        }

        [DebugOnly]
        public async void TestPause()
        {
            var unused = await _client.SendCommandAsync<ControlPauseResponse>(new ControlPauseCommand());
        }

        [DebugOnly]
        public async void TestPlay()
        {
            var unused = await _client.SendCommandAsync<ControlPlayResponse>(new ControlPlayCommand());
        }

        [DebugOnly]
        public async void TestRewind()
        {
            var unused = await _client.SendCommandAsync<ControlRewindResponse>(new ControlRewindCommand());
        }

        [DebugOnly]
        public async void TestStop()
        {
            var unused = await _client.SendCommandAsync<ControlStopResponse>(new ControlStopCommand());
        }
        #endregion

        #region Apps
        [DebugOnly]
        public async void TestGetForeground()
        {
            var unused = await _client.SendCommandAsync<GetForegroundResponse>(new GetForegroundCommand());
        }

        [DebugOnly]
        public async void TestGetLaunchPoints()
        {
            var unused = await _client.SendCommandAsync<ListLaunchPointsResponse>(new ListLaunchPointsCommand());
        }

        [DebugOnly]
        public async void TestClose()
        {
            var unused = await _client.SendCommandAsync<CloseCommandResponse>(new CloseCommand { Id = "now.tv"});
        }

        [DebugOnly]
        public async void TestGetAppState()
        {
            var unused = await _client.SendCommandAsync<GetAppStateResponse>(new GetAppStateCommand { Id = "now.tv"});
        }

        [DebugOnly]
        public async void TestLaunchApp()
        {
            var unused = await _client.SendCommandAsync<LaunchAppResponse>(new LaunchAppCommand { Id = "now.tv"});
        }

        [DebugOnly]
        public async void TestOpenApp()
        {
            var unused = await _client.SendCommandAsync<OpenAppResponse>(new OpenAppCommand { Id = "now.tv"});
        }

        [DebugOnly]
        public async void TestLaunchBrowser()
        {
            var unused = await _client.SendCommandAsync<LaunchBrowserResponse>(new LaunchBrowserCommand {BrowserUrl = "https://www.google.com"});
        }

        [DebugOnly]
        public async void TestLaunchYouTube()
        {
            var unused = await _client.SendCommandAsync<LaunchYouTubeVideoResponse>(new LaunchYouTubeVideoCommand {VideoId = "AmWCh8Vctr4"});
        }
        #endregion

        #region Notifications
        [DebugOnly]
        public async void TestToast()
        {
            var unused = await _client.SendCommandAsync<ToastResponse>(new ToastCommand { Message = "Hello world!"});
        }
        #endregion

        #region TV
        [DebugOnly]
        public async void TestChannelDown()
        {
            var unused = await _client.SendCommandAsync<ChannelDownResponse>(new ChannelDownCommand());
        }

        [DebugOnly]
        public async void TestChannelList()
        {
            var unused = await _client.SendCommandAsync<ChannelListResponse>(new ChannelListCommand());
        }

        [DebugOnly]
        public async void TestChannelUp()
        {
            var unused = await _client.SendCommandAsync<ChannelUpResponse>(new ChannelUpCommand());
        }

        [DebugOnly]
        public async void TestCurrentChannel()
        {
            var unused = await _client.SendCommandAsync<GetCurrentChannelResponse>(new GetCurrentChannelCommand());
        }

        [DebugOnly]
        public async void TestProgrammeInfo()
        {
            var unused = await _client.SendCommandAsync<GetChannelProgramInfoResponse>(new GetChannelProgramInfoCommand());
        }

        [DebugOnly]
        public async void Test3d()
        {
            var unused = await _client.SendCommandAsync<ThreeDimensionStatusResponse>(new ThreeDimensionStatusCommand());
        }

        [DebugOnly]
        public async void TestExternalInputList()
        {
            var unused = await _client.SendCommandAsync<ExternalInputListResponse>(new ExternalInputListCommand());
        }

        [DebugOnly]
        public async void TestSwitchInput()
        {
            var unused = await _client.SendCommandAsync<SwitchInputResponse>(new SwitchInputCommand {InputId = "HDMI_1"});
        }
        #endregion

        #region API
        [DebugOnly]
        public async void TestGetMouse()
        {
            var unused = await _client.SendCommandAsync<MouseGetResponse>(new MouseGetCommand());
        }

        [DebugOnly]
        public async void TestGetServiceList()
        {
            var unused = await _client.SendCommandAsync<ServiceListResponse>(new ServiceListGetCommand());
        }
        #endregion

        #region Buttons
        [DebugOnly]
        public async void TestButton()
        {
            await _client.SendButtonAsync(ButtonTypes.Home);
        }
        #endregion
    }
}
