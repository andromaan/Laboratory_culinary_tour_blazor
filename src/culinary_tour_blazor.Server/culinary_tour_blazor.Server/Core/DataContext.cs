using culinary_tour_blazor.Server.Core.Entities;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace culinary_tour_blazor.Server.Core
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<GastroFacility> GastroFacilities { get; set; }
        public DbSet<FacilityType> FacilityTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FacilityType>().HasData(
                new List<FacilityType>
                {
                    new FacilityType {Id = 1, Name = "Кафе"},
                    new FacilityType {Id = 2, Name = "Забігайлівка"},
                    new FacilityType {Id = 3, Name = "Ресторан"}
                }
                );
            modelBuilder.Entity<Cuisine>().HasData(
                new List<Cuisine>
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
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
