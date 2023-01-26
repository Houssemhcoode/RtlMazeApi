using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rtl.TvMaze.DataAccess.Entities;
using Rtl.TvMaze.Implementation.Services.Interfaces;
using Rtl.TvMaze.WebApi.Controllers.Dtos;
using Rtl.TvMaze.WebApi.Extensions;

namespace Rtl.TvMaze.WebApi.Controllers
{
    [ApiController]
    [Route("show")]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;
        private readonly ILogger<ShowController> _logger;

        public ShowController(
            IShowService showService,
            ILogger<ShowController> logger)
        {
            _showService = showService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ShowDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<ShowDto>> Get()
        {
            var shows = (await _showService
                .GetAllShows())
                .ToDto()
                .Select(s => new ShowDto
                {
                    Name = s.Name,
                    Id = s.Id,
                    Cast = s.Cast
                    .OrderByDescending(c => c.Birthday)
                    .Select(c => new CastDto
                    {
                        Id = c.Id,
                        Birthday = c.Birthday,
                        Name = c.Name
                    }),
                });

            return shows;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ShowDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ShowDto GetById(int id)
        {
            return null;
        }
    }
}
