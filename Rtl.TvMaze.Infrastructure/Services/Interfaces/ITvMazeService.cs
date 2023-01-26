using System.Collections.Generic;
using System.Threading.Tasks;
using Rtl.TvMaze.Infrastructure.Apis.Dtos;

namespace Rtl.TvMaze.Infrastructure.Services.Interfaces
{
    public interface ITvMazeService
    {
        Task<IEnumerable<ShowDto>> GetAllTvShows();

        Task<IEnumerable<CastDto>> GetCastForShow(int showId);
    }
}
