using MongoDB.Driver;
using Rtl.TvMaze.DataAccess.Entities;

namespace Rtl.TvMaze.DataAccess
{
    public interface IDbContext
    {
        IMongoCollection<ShowEntity> Shows { get; }
    }
}