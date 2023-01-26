using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Rtl.TvMaze.DataAccess.Entities;
using Rtl.TvMaze.DataAccess.Repositories.Interfaces;

namespace Rtl.TvMaze.DataAccess.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly IDbContext _dbContext;

        public ShowRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Upsert(IEnumerable<ShowEntity> entities)
        {
            List<UpdateOneModel<ShowEntity>> requests = new List<UpdateOneModel<ShowEntity>>(entities.Count());
            foreach (var entity in entities)
            {
                var filter = new FilterDefinitionBuilder<ShowEntity>().Where(m => m.Id == entity.Id);
                var update = new UpdateDefinitionBuilder<ShowEntity>()
                    .Set(m => m.Name, entity.Name)
                    .Set(m => m.Cast, entity.Cast);
                var request = new UpdateOneModel<ShowEntity>(filter, update);
                request.IsUpsert = true;
                requests.Add(request);
            }

            await _dbContext.Shows.BulkWriteAsync(requests);
        }

        public async Task<IEnumerable<ShowEntity>> GetAllShows()
        {

            return await _dbContext.Shows.AsQueryable().ToListAsync();
        }
    }
}
