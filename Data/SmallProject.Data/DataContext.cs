using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SmallProject.Domain;
using SmallProject.Settings;
using System;

namespace SmallProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
        }

        public DbSet<DistancePrice> DistancePrices { get; set; }
        public DbSet<VolumePrice> VolumePrices { get; set; }

        public DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DistancePrice>().ToTable("DistancePrices", "dbo");
            modelBuilder.Entity<VolumePrice>().ToTable("VolumePrices", "dbo");
            modelBuilder.Entity<Offer>().ToTable("Offers", "dbo");
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
