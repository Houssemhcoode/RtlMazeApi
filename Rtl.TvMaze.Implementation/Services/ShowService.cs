using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rtl.TvMaze.DataAccess.Repositories.Interfaces;
using Rtl.TvMaze.Implementation.Extensions;
using Rtl.TvMaze.Implementation.Models;
using Rtl.TvMaze.Implementation.Services.Interfaces;
using Rtl.TvMaze.Infrastructure.Services.Interfaces;

namespace Rtl.TvMaze.Implementation.Services
{
    public class ShowService : IShowService
    {
        private readonly ITvMazeService _tvMazeService;
        private readonly IShowRepository _showRepository;

        public ShowService(
            ITvMazeService tvMazeService,
            IShowRepository showRepository)
        {
            _tvMazeService = tvMazeService;
            _showRepository = showRepository;
        }

        public async Task SyncAllShowsFromTvMaze()
        {
            // fetch all shows
            IEnumerable<Show> allShows = (await _tvMazeService
                .GetAllTvShows())
                .Select(show => show.ToModel());

            // fetch cast per show
            foreach (var show in allShows)
            {
                show.Cast = (await _tvMazeService.GetCastForShow(show.Id)).ToModels();
            }

            // sync shows with database
            await _showRepository.Upsert(allShows.ToEntities());
        }

        public async Task<IEnumerable<Show>> GetAllShows()
        {
            return (await _showRepository.GetAllShows()).ToModels();
        }
    }
}
