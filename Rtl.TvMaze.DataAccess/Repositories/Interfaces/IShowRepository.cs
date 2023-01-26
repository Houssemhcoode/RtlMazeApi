using System.Collections.Generic;
using System.Threading.Tasks;
using Rtl.TvMaze.DataAccess.Entities;

namespace Rtl.TvMaze.DataAccess.Repositories.Interfaces
{
    public interface IShowRepository
    {
        Task Upsert(IEnumerable<ShowEntity> entities);

        Task<IEnumerable<ShowEntity>> GetAllShows();
    }
}
