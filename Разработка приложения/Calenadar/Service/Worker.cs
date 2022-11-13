using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Calendar.Service
{
    public class Worker: BackgroundService
    {
        private readonly NoticeService _noticeService;

        private readonly ILogger<BackgroundService> _logger;

        public Worker(NoticeService noticeService, ILogger<BackgroundService> logger)
        {
            _noticeService = noticeService;
            _logger= logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _noticeService.Process();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
