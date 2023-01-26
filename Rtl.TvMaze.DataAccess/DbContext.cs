using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Rtl.TvMaze.DataAccess.Entities;

namespace Rtl.TvMaze.DataAccess
{
    public class DbContext : IDbContext
    {
        private readonly IMongoDatabase _db;
        public DbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _db = client.GetDatabase("RtlTvMaze");
        }
        public IMongoCollection<ShowEntity> Shows => _db.GetCollection<ShowEntity>("Shows");
    }
}
