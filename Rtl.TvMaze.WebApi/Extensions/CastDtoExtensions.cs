using System.Collections.Generic;
using Rtl.TvMaze.Implementation.Models;
using Rtl.TvMaze.WebApi.Controllers.Dtos;

namespace Rtl.TvMaze.WebApi.Extensions
{
    public static class CastDtoExtensions
    {
        public static IEnumerable<CastDto> ToDto(this IEnumerable<Cast> entities)
        {
            foreach (var entity in entities)
            {
                yield return entity.ToDto();
            }
        }

        public static CastDto ToDto(this Cast entity)
        {
            return new CastDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Birthday = entity.Birthday
            };
        }
    }
}
