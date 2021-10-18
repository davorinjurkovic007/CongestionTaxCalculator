using CongestionTaxCalculator.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CongestionTaxCalculator.Data.Configuration
{
    class TaxAmountConfiguration : IEntityTypeConfiguration<TaxAmount>
    {
        public void Configure(EntityTypeBuilder<TaxAmount> builder)
        {
            builder.HasData(
                new TaxAmount { Id = 1, CityId = 1, TimeIn = new TimeSpan(0,0,0), TimeOut = new TimeSpan(6,0,0), Amount = 0, PeakSeason = false },
                new TaxAmount { Id = 2, CityId = 1, TimeIn = new TimeSpan(6,0,0), TimeOut = new TimeSpan(6,30,0), Amount = 9, PeakSeason = false },
                new TaxAmount { Id = 3, CityId = 1, TimeIn = new TimeSpan(6, 30, 0), TimeOut = new TimeSpan(7, 0, 0), Amount = 16, PeakSeason = false },
                new TaxAmount { Id = 4, CityId = 1, TimeIn = new TimeSpan(7, 0, 0), TimeOut = new TimeSpan(8, 0, 0), Amount = 22, PeakSeason = false },
                new TaxAmount { Id = 5, CityId = 1, TimeIn = new TimeSpan(8, 0, 0), TimeOut = new TimeSpan(8, 30, 0), Amount = 16, PeakSeason = false },
                new TaxAmount { Id = 6, CityId = 1, TimeIn = new TimeSpan(8, 30, 0), TimeOut = new TimeSpan(15, 0, 0), Amount = 9, PeakSeason = false },
                new TaxAmount { Id = 7, CityId = 1, TimeIn = new TimeSpan(15, 0, 0), TimeOut = new TimeSpan(15, 30, 0), Amount = 16, PeakSeason = false },
                new TaxAmount { Id = 8, CityId = 1, TimeIn = new TimeSpan(15, 30, 0), TimeOut = new TimeSpan(17, 0, 0), Amount = 22, PeakSeason = false },
                new TaxAmount { Id = 9, CityId = 1, TimeIn = new TimeSpan(17, 0, 0), TimeOut = new TimeSpan(18, 0, 0), Amount = 16, PeakSeason = false },
                new TaxAmount { Id = 10, CityId = 1, TimeIn = new TimeSpan(18, 0, 0), TimeOut = new TimeSpan(18, 30, 0), Amount = 9, PeakSeason = false },
                new TaxAmount { Id = 11, CityId = 1, TimeIn = new TimeSpan(18, 30, 0), TimeOut = new TimeSpan(0,0,0), Amount = 0, PeakSeason = false },

                new TaxAmount { Id = 12, CityId = 2, TimeIn = new TimeSpan(0, 0, 0), TimeOut = new TimeSpan(6, 0, 0), Amount = 0, PeakSeason = true },
                new TaxAmount { Id = 13, CityId = 2, TimeIn = new TimeSpan(6, 0, 0), TimeOut = new TimeSpan(6, 30, 0), Amount = 15, PeakSeason = true },
                new TaxAmount { Id = 14, CityId = 2, TimeIn = new TimeSpan(6, 30, 0), TimeOut = new TimeSpan(7, 0, 0), Amount = 30, PeakSeason = true },
                new TaxAmount { Id = 15, CityId = 2, TimeIn = new TimeSpan(7, 0, 0), TimeOut = new TimeSpan(8, 30, 0), Amount = 45, PeakSeason = true },
                new TaxAmount { Id = 16, CityId = 2, TimeIn = new TimeSpan(8, 30, 0), TimeOut = new TimeSpan(9, 0, 0), Amount = 30, PeakSeason = true },
                new TaxAmount { Id = 17, CityId = 2, TimeIn = new TimeSpan(9, 0, 0), TimeOut = new TimeSpan(9, 30, 0), Amount = 20, PeakSeason = true },
                new TaxAmount { Id = 18, CityId = 2, TimeIn = new TimeSpan(9, 30, 0), TimeOut = new TimeSpan(15, 0, 0), Amount = 11, PeakSeason = true },
                new TaxAmount { Id = 19, CityId = 2, TimeIn = new TimeSpan(15, 0, 0), TimeOut = new TimeSpan(15, 30, 0), Amount = 20, PeakSeason = true },
                new TaxAmount { Id = 20, CityId = 2, TimeIn = new TimeSpan(15, 30, 0), TimeOut = new TimeSpan(16, 0, 0), Amount = 30, PeakSeason = true },
                new TaxAmount { Id = 21, CityId = 2, TimeIn = new TimeSpan(16, 0, 0), TimeOut = new TimeSpan(17, 30, 0), Amount = 45, PeakSeason = true },
                new TaxAmount { Id = 22, CityId = 2, TimeIn = new TimeSpan(17, 30, 0), TimeOut = new TimeSpan(18, 0, 0), Amount = 30, PeakSeason = true },
                new TaxAmount { Id = 23, CityId = 2, TimeIn = new TimeSpan(18, 0, 0), TimeOut = new TimeSpan(18, 30, 0), Amount = 20, PeakSeason = true },
                new TaxAmount { Id = 24, CityId = 2, TimeIn = new TimeSpan(18, 30, 0), TimeOut = new TimeSpan(0, 0, 0), Amount = 0, PeakSeason = true },

                new TaxAmount { Id = 25, CityId = 2, TimeIn = new TimeSpan(0, 0, 0), TimeOut = new TimeSpan(6, 0, 0), Amount = 0, PeakSeason = false },
                new TaxAmount { Id = 26, CityId = 2, TimeIn = new TimeSpan(6, 0, 0), TimeOut = new TimeSpan(6, 30, 0), Amount = 15, PeakSeason = false },
                new TaxAmount { Id = 27, CityId = 2, TimeIn = new TimeSpan(6, 30, 0), TimeOut = new TimeSpan(7, 0, 0), Amount = 25, PeakSeason = false },
                new TaxAmount { Id = 28, CityId = 2, TimeIn = new TimeSpan(7, 0, 0), TimeOut = new TimeSpan(8, 30, 0), Amount = 35, PeakSeason = false },
                new TaxAmount { Id = 29, CityId = 2, TimeIn = new TimeSpan(8, 30, 0), TimeOut = new TimeSpan(9, 0, 0), Amount = 25, PeakSeason = false },
                new TaxAmount { Id = 30, CityId = 2, TimeIn = new TimeSpan(9, 0, 0), TimeOut = new TimeSpan(9, 30, 0), Amount = 15, PeakSeason = false },
                new TaxAmount { Id = 31, CityId = 2, TimeIn = new TimeSpan(9, 30, 0), TimeOut = new TimeSpan(15, 0, 0), Amount = 11, PeakSeason = false },
                new TaxAmount { Id = 32, CityId = 2, TimeIn = new TimeSpan(15, 0, 0), TimeOut = new TimeSpan(15, 30, 0), Amount = 15, PeakSeason = false },
                new TaxAmount { Id = 33, CityId = 2, TimeIn = new TimeSpan(15, 30, 0), TimeOut = new TimeSpan(16, 0, 0), Amount = 25, PeakSeason = false },
                new TaxAmount { Id = 34, CityId = 2, TimeIn = new TimeSpan(16, 0, 0), TimeOut = new TimeSpan(17, 30, 0), Amount = 35, PeakSeason = false },
                new TaxAmount { Id = 35, CityId = 2, TimeIn = new TimeSpan(17, 30, 0), TimeOut = new TimeSpan(18, 0, 0), Amount = 25, PeakSeason = false },
                new TaxAmount { Id = 36, CityId = 2, TimeIn = new TimeSpan(18, 0, 0), TimeOut = new TimeSpan(18, 30, 0), Amount = 15, PeakSeason = false },
                new TaxAmount { Id = 37, CityId = 2, TimeIn = new TimeSpan(18, 30, 0), TimeOut = new TimeSpan(0, 0, 0), Amount = 0, PeakSeason = false }
            );
        }
    }
}
