using CongestionTaxCalculator.Data.Configuration;
using CongestionTaxCalculator.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<FreeOfChargeDay> FreeOfChargeDays { get; set; }
        public DbSet<PeakDay> PeakDays { get; set; }
        public DbSet<TaxAmount> TaxAmounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new FreeOfChargeDayConfiguration());
            modelBuilder.ApplyConfiguration(new PeakDayConfiguration());
            modelBuilder.ApplyConfiguration(new TaxAmountConfiguration());
        }

    }
}
