using culinary_tour.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;   
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace culinary_tour.Core.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<GastroFacility> GastroFacilities { get; set; }
        public DbSet<FacilityType> FacilityTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GastroFacility>()
            .HasMany(x => x.Cuisines)
            .WithMany(x => x.GastroFacilities)
            .UsingEntity(x => x.ToTable("GastroFacilitieCuisine"));

            base.OnModelCreating(builder);

            DataSeed.Seed(builder);
        }
    }
}
