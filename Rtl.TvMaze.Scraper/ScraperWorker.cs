using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rtl.TvMaze.Implementation.Services.Interfaces;

namespace Rtl.TvMaze.Scraper
{
    public class ScraperWorker : IHostedService
    {
        private readonly IShowService _showService;
        private readonly ILogger<ScraperWorker> _logger;

        public ScraperWorker(
            IShowService showService,
            ILogger<ScraperWorker> logger)
        {
            _showService = showService;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // No inifinite loop since we want to sync only once...
            await _showService.SyncAllShowsFromTvMaze();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            // Nothing to dispose atm..

            await Task.CompletedTask;
        }
    }
}
