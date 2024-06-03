using culinary_tour.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace culinary_tour.Core.Context
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            var typeId = _seedTypes(builder);
            var cuisineId = _seedCuisines(builder);

            _seedGastroFacilities(builder, typeId, cuisineId);
        }

        
        private static int _seedTypes(ModelBuilder builder)
        {
            var typeCafe = new FacilityType
            {
                Id = 1,
                Name = "Кафе"
            };

            var typeZabigaylivka = new FacilityType
            {
                Id = 2,
                Name = "Забігайлівка"
            };

            var typeRestaurant = new FacilityType
            {
                Id = 3,
                Name = "Ресторан"
            };

            builder.Entity<FacilityType>()
                .HasData(typeCafe, typeZabigaylivka, typeRestaurant);

            return typeCafe.Id;
        }

        private static Cuisine _seedCuisines(ModelBuilder builder)
        {
            var cuisines = new List<Cuisine>
            {
                new Cuisine { Id = 1, Name = "Італійська" },
                new Cuisine { Id = 2, Name = "Французька" },
                new Cuisine { Id = 3, Name = "Іспанська" },
                new Cuisine { Id = 4, Name = "Японська" },
                new Cuisine { Id = 5, Name = "Китайська" },
                new Cuisine { Id = 6, Name = "Індійська" },
                new Cuisine { Id = 7, Name = "Тайська" },
                new Cuisine { Id = 8, Name = "Мексиканська" },
                new Cuisine { Id = 9, Name = "Грецька" },
                new Cuisine { Id = 10, Name = "Турецька" },
                new Cuisine { Id = 11, Name = "Українська" }
            };

            builder.Entity<Cuisine>().HasData(cuisines);

            return cuisines.FirstOrDefault(x=> x.Id == 11);
        }


        private static void _seedGastroFacilities(ModelBuilder builder, int typeId, Cuisine cuisine)
        {
            var gastroFacilities = new List<GastroFacility>
            {
                new GastroFacility
                {
                    Id = Guid.NewGuid(),
                    Name = "Заклад 1",
                    TypeId = typeId,
                },
                new GastroFacility
                {
                    Id = Guid.NewGuid(),
                    Name = "Заклад 2",
                    TypeId = typeId,
                }
            };

            builder.Entity<GastroFacility>()
                .HasData(gastroFacilities);
        }
    }
}
