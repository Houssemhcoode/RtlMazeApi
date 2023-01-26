using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rtl.TvMaze.DataAccess;
using Rtl.TvMaze.Implementation;
using Rtl.TvMaze.Infrastructure;

namespace Rtl.TvMaze.Scraper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ScraperWorker>();

                    services
                        .ConfigureDataAccess(hostContext.Configuration)
                        .ConfigureInfrastructure(hostContext.Configuration)
                        .ConfigureImplementation();


                });
    }
}
