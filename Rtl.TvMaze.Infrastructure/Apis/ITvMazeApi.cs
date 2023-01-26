using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Rtl.TvMaze.Infrastructure.Apis.Dtos;

namespace Rtl.TvMaze.Infrastructure.Apis
{
    public interface ITvMazeApi
    {
        [Get("/shows?page={pageNo}")]
        Task<IEnumerable<ShowDto>> GetShows(int pageNo);

        [Get("/shows/{showId}/cast")]
        Task<IEnumerable<CastDto>> GetCast(int showId);
    }
}
