using System.Collections.Generic;
using Rtl.TvMaze.DataAccess.Entities;
using Rtl.TvMaze.Implementation.Models;
using Rtl.TvMaze.Infrastructure.Apis.Dtos;

namespace Rtl.TvMaze.Implementation.Extensions
{
    public static class ShowExtensions
    {
        public static IEnumerable<Show> ToModels(this IEnumerable<ShowDto> dtos)
        {
            foreach (var dto in dtos)
            {
                yield return dto.ToModel();
            }
        }

        public static IEnumerable<Show> ToModels(this IEnumerable<ShowEntity> entities)
        {
            foreach (var entity in entities)
            {
                yield return entity.ToModel();
            }
        }

        public static Show ToModel(this ShowDto dto)
        {
            return new Show()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static Show ToModel(this ShowEntity entity)
        {
            return new Show()
            {
                Id = entity.Id,
                Name = entity.Name,
                Cast = entity.Cast?.ToModels()
            };
        }


        public static IEnumerable<ShowEntity> ToEntities(this IEnumerable<Show> models)
        {
            foreach (var model in models)
            {
                yield return model.ToEntity();
            }
        }

        public static ShowEntity ToEntity(this Show model)
        {
            return new ShowEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Cast = model.Cast?.ToEntities()
            };
        }
    }
}
