using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Polly;
using Refit;
using Rtl.TvMaze.Infrastructure.Apis;
using Rtl.TvMaze.Infrastructure.Apis.Dtos;
using Rtl.TvMaze.Infrastructure.Services.Interfaces;

namespace Rtl.TvMaze.Infrastructure.Services
{
    public class TvMazeService : ITvMazeService
    {
        private static List<TimeSpan> SleepDurations = new List<TimeSpan>()
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3),
            TimeSpan.FromSeconds(5),
            TimeSpan.FromSeconds(10)
        };

        private const int MAX_RESULTS_PER_PAGE = 250;
        private readonly ITvMazeApi _tvMazeApi;

        public TvMazeService(ITvMazeApi tvMazeApi)
        {
            _tvMazeApi = tvMazeApi;
        }

        public async Task<IEnumerable<ShowDto>> GetAllTvShows()
        {
            var resultCount = 0;
            var currentPage = 0;

            IEnumerable<ShowDto> results = new List<ShowDto>();

            while (currentPage == 0 || resultCount == MAX_RESULTS_PER_PAGE)
            {
                await Policy
                    .Handle<ApiException>(ex => ex.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                    .WaitAndRetryAsync(SleepDurations)
                    .ExecuteAsync(async () =>
                    {
                        IEnumerable<ShowDto> iterationResults = await _tvMazeApi.GetShows(currentPage);
                        resultCount = iterationResults.Count();

                        results = results.Union(iterationResults);

                        currentPage++;
                    });
            }

            return results;
        }

        public async Task<IEnumerable<CastDto>> GetCastForShow(int showId)
        {
            IEnumerable<CastDto> results = new List<CastDto>();

            await Policy
                .Handle<ApiException>(ex => ex.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                .WaitAndRetryAsync(SleepDurations)
                .ExecuteAsync(async () =>
                {
                    results = await _tvMazeApi.GetCast(showId);
                });

            return results;
        }
    }
}
