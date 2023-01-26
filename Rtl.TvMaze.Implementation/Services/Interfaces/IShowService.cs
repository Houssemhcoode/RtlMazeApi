using System.Collections.Generic;
using System.Threading.Tasks;
using Rtl.TvMaze.Implementation.Models;

namespace Rtl.TvMaze.Implementation.Services.Interfaces
{
    public interface IShowService
    {
        Task SyncAllShowsFromTvMaze();

        Task<IEnumerable<Show>> GetAllShows();
    }
}
