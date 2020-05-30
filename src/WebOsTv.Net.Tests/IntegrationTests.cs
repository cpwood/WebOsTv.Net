using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
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
        private readonly ITestOutputHelper _output;
        private readonly Client _client;

        public IntegrationTests(ITestOutputHelper output)
        {
            _output = output;
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
            var response = await _client.SendCommandAsync<PowerOffResponse>(new PowerOffCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestVolumeGet()
        {
            var response = await _client.SendCommandAsync<VolumeGetResponse>(new VolumeGetCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestVolumeSet()
        {
            var response = await _client.SendCommandAsync<VolumeSetResponse>(new VolumeSetCommand { Volume = 0 });
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestVolumeUp()
        {
            var response = await _client.SendCommandAsync<VolumeUpResponse>(new VolumeUpCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestVolumeDown()
        {
            var response = await _client.SendCommandAsync<VolumeDownResponse>(new VolumeDownCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestMute()
        {
            var response = await _client.SendCommandAsync<VolumeMuteResponse>(new VolumeMuteCommand { Mute = true });
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestUnmute()
        {
            var response = await _client.SendCommandAsync<VolumeMuteResponse>(new VolumeMuteCommand { Mute = false });
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }
        #endregion

        #region Media
        [DebugOnly]
        public async void TestFastForward()
        {
            var response = await _client.SendCommandAsync<ControlFastForwardResponse>(new ControlFastForwardCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestPause()
        {
            var response = await _client.SendCommandAsync<ControlPauseResponse>(new ControlPauseCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestPlay()
        {
            var response = await _client.SendCommandAsync<ControlPlayResponse>(new ControlPlayCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestRewind()
        {
            var response = await _client.SendCommandAsync<ControlRewindResponse>(new ControlRewindCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestStop()
        {
            var response = await _client.SendCommandAsync<ControlStopResponse>(new ControlStopCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }
        #endregion

        #region Apps
        [DebugOnly]
        public async void TestGetForeground()
        {
            var response = await _client.SendCommandAsync<GetForegroundResponse>(new GetForegroundCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestGetLaunchPoints()
        {
            var response = await _client.SendCommandAsync<ListLaunchPointsResponse>(new ListLaunchPointsCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestClose()
        {
            var response = await _client.SendCommandAsync<CloseCommandResponse>(new CloseCommand { Id = "netflix"});
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestGetAppState()
        {
            var response = await _client.SendCommandAsync<GetAppStateResponse>(new GetAppStateCommand { Id = "netflix"});
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestLaunchApp()
        {
            var response = await _client.SendCommandAsync<LaunchAppResponse>(new LaunchAppCommand { Id = "netflix"});
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestOpenApp()
        {
            var response = await _client.SendCommandAsync<OpenAppResponse>(new OpenAppCommand { Id = "netflix"});
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestLaunchBrowser()
        {
            var response = await _client.SendCommandAsync<LaunchBrowserResponse>(new LaunchBrowserCommand {BrowserUrl = "https://www.google.com"});
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestLaunchYouTube()
        {
            var response = await _client.SendCommandAsync<LaunchYouTubeVideoResponse>(new LaunchYouTubeVideoCommand {VideoId = "AmWCh8Vctr4"});
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }
        #endregion

        #region Notifications
        [DebugOnly]
        public async void TestToast()
        {
            var response = await _client.SendCommandAsync<ToastResponse>(new ToastCommand { Message = "Hello world!"});
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }
        #endregion

        #region TV
        [DebugOnly]
        public async void TestChannelDown()
        {
            var response = await _client.SendCommandAsync<ChannelDownResponse>(new ChannelDownCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestChannelList()
        {
            var response = await _client.SendCommandAsync<ChannelListResponse>(new ChannelListCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestChannelUp()
        {
            var response = await _client.SendCommandAsync<ChannelUpResponse>(new ChannelUpCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestCurrentChannel()
        {
            var response = await _client.SendCommandAsync<GetCurrentChannelResponse>(new GetCurrentChannelCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestProgrammeInfo()
        {
            var response = await _client.SendCommandAsync<GetChannelProgramInfoResponse>(new GetChannelProgramInfoCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void Test3d()
        {
            var response = await _client.SendCommandAsync<ThreeDimensionStatusResponse>(new ThreeDimensionStatusCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestExternalInputList()
        {
            var response = await _client.SendCommandAsync<ExternalInputListResponse>(new ExternalInputListCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestSwitchInput()
        {
            var response = await _client.SendCommandAsync<SwitchInputResponse>(new SwitchInputCommand {InputId = "HDMI_1"});
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }
        #endregion

        #region API
        [DebugOnly]
        public async void TestGetMouse()
        {
            var response = await _client.SendCommandAsync<MouseGetResponse>(new MouseGetCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
        }

        [DebugOnly]
        public async void TestGetServiceList()
        {
            var response = await _client.SendCommandAsync<ServiceListResponse>(new ServiceListGetCommand());
            _output.WriteLine(JsonConvert.SerializeObject(response));
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
