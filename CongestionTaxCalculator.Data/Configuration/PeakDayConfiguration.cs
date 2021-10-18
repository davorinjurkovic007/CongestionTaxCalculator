using CongestionTaxCalculator.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CongestionTaxCalculator.Data.Configuration
{
    class PeakDayConfiguration : IEntityTypeConfiguration<PeakDay>
    {
        public void Configure(EntityTypeBuilder<PeakDay> builder)
        {
            builder.HasData(
                new PeakDay { Id = 1, CityId = 2, PeakBegin = new DateTime(2013, 3, 1), PeakEnd = new DateTime(2013, 6, 21)},
                new PeakDay { Id = 2, CityId = 2, PeakBegin = new DateTime(2013, 8, 15), PeakEnd = new DateTime(2013, 11, 30)}
            );
        }
    }
}
