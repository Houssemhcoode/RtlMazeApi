using Microsoft.Extensions.DependencyInjection;
using Rtl.TvMaze.Implementation.Services;
using Rtl.TvMaze.Implementation.Services.Interfaces;

namespace Rtl.TvMaze.Implementation
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection ConfigureImplementation(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IShowService, ShowService>();

            return serviceCollection;
        }
    }
}
