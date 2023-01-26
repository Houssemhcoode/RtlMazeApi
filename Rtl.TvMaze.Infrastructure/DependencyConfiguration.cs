using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Rtl.TvMaze.Infrastructure.Apis;
using Rtl.TvMaze.Infrastructure.Services;
using Rtl.TvMaze.Infrastructure.Services.Interfaces;

namespace Rtl.TvMaze.Infrastructure
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var tvMazeBaseUri = configuration["TvMaze:BaseUri"];

            serviceCollection
                .AddRefitClient<ITvMazeApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(tvMazeBaseUri));


            serviceCollection.AddTransient<ITvMazeService, TvMazeService>();

            return serviceCollection;
        }
    }
}
