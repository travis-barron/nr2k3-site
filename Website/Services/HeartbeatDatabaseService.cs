using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Website.racing;
using Website.CachingLayer;
using Microsoft.Extensions.Logging;

namespace Website.Services
{
    public class HeartbeatDatabaseService : BackgroundService
    {
        ILogger _logger;
        TimeSpan _interval;
        long _version;

        public HeartbeatDatabaseService(ILogger<HeartbeatDatabaseService> logger)
        {
            _logger = logger;
            _interval = TimeSpan.FromMinutes(5.0);
            _version = GetLatestVersion();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var latestVersion = GetLatestVersion();
                if (_version != latestVersion)
                {
                    StaticCache.LoadStaticCache();
                    _version = latestVersion;
                }
                await Task.Delay(_interval, stoppingToken);
            }
        }

        private long GetLatestVersion()
        {
            var racingContext = new Website.racing.racingContext();
            return racingContext.Config.ToList().Last().Version;   
        }
    }
}
