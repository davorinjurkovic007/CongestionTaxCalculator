using CongestionTaxCalculator.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CongestionTaxCalculator.Data.Configuration
{
    class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                new City { Id = 1, Name = "Gothenburg", SingleChargeRule = true, PeakSeason = false, MaxDayPeakSeason = 60, MaxDayOffPeakSeason = 60 },
                new City { Id = 2, Name = "Stockholm", SingleChargeRule = false, PeakSeason = true, MaxDayPeakSeason = 135, MaxDayOffPeakSeason = 105 }
            );
        }
    }
}
