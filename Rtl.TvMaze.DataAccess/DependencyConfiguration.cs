using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rtl.TvMaze.DataAccess.Repositories;
using Rtl.TvMaze.DataAccess.Repositories.Interfaces;

namespace Rtl.TvMaze.DataAccess
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection ConfigureDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddSingleton<IShowRepository>(new ShowRepository(new DbContext(configuration)));

            return serviceCollection;
        }
    }
}
