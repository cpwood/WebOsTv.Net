﻿using System;
using System.Threading.Tasks;
using WebOsTv.Net.Services;

namespace WebOsTv.Net
{
    public class Service : IService
    {
        private readonly IClient _client;

        public Service() : this(new Client())
        {
        }

        public Service(IClient client)
        {
            _client = client;

            Api = new ApiService(client);
            Apps = new AppsService(client);
            Audio = new AudioService(client);
            Control = new ControlService(client);
            Notifications = new NotificationService(client);
            Tv = new TvService(client);
        }

        public ApiService Api { get; }
        public AppsService Apps { get; }
        public AudioService Audio { get; }
        public ControlService Control { get; }
        public NotificationService Notifications { get; }
        public TvService Tv { get; }

        public async Task ConnectAsync(string hostName)
        {
            await _client.ConnectAsync(hostName);
        }

        public void Close()
        {
            _client.Close();
            ((IDisposable)_client)?.Dispose();
        }
    }
}
