using System.Collections.Generic;

namespace Rtl.TvMaze.WebApi.Controllers.Dtos
{
    public class ShowDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CastDto> Cast { get; set; }
    }
}
