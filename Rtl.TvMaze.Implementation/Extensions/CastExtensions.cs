using System.Collections.Generic;
using Rtl.TvMaze.DataAccess.Entities;
using Rtl.TvMaze.Implementation.Models;
using Rtl.TvMaze.Infrastructure.Apis.Dtos;

namespace Rtl.TvMaze.Implementation.Extensions
{
    public static class CastExtensions
    {
        public static IEnumerable<Cast> ToModels(this IEnumerable<CastDto> dtos)
        {
            foreach (var dto in dtos)
            {
                yield return dto.ToModel();
            }
        }

        public static Cast ToModel(this CastDto dto)
        {
            return new Cast()
            {
                Id = dto.Id,
                Name = dto.Name,
                Birthday = dto.Birthday
            };
        }

        public static IEnumerable<Cast> ToModels(this IEnumerable<CastEntity> entities)
        {
            foreach (var entity in entities)
            {
                yield return entity.ToModel();
            }
        }

        public static Cast ToModel(this CastEntity entity)
        {
            return new Cast()
            {
                Id = entity.Id,
                Name = entity.Name,
                Birthday = entity.Birthday
            };
        }

        public static IEnumerable<CastEntity> ToEntities(this IEnumerable<Cast> models)
        {
            foreach (var model in models)
            {
                yield return model.ToEntity();
            }
        }

        public static CastEntity ToEntity(this Cast model)
        {
            return new CastEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Birthday = model.Birthday
            };
        }
    }
}
