using CongestionTaxCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CongestionTaxCalculator.Services
{
    public class CongestionTaxCalculatorRepository : ICongestionTaxCalculatorRepository
    {
        private readonly ApplicationDbContext context;

        public CongestionTaxCalculatorRepository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool CityExist(string cityName)
        {
            if(string.IsNullOrEmpty(cityName))
            {
                throw new ArgumentNullException(nameof(cityName));
            }

            return context.Cities.Any(city => city.Name == cityName);
        }

        public bool IsFreOfChargeDay(DateTime date, string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                throw new ArgumentNullException(nameof(cityName));
            }

            var containg = context.FreeOfChargeDays
                .Join(
                    context.Cities,
                    free => free.City.Id,
                    city => city.Id,
                    (free, city) => new
                    {
                        GivenDate = free.Date,
                        GivenName = city.Name
                    }).Where(x => x.GivenDate.Date == date.Date && x.GivenName == cityName).ToList();

            if(containg.Count != 0)
            {
                return true;
            }


            return false;
        }

        public bool IsSingleChargeRule(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                throw new ArgumentNullException(nameof(cityName));
            }

            return context.Cities.Where(city => city.Name == cityName).Select(c => c.SingleChargeRule).FirstOrDefault();
        }

        public bool IsPeakSeason(DateTime date, string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                throw new ArgumentNullException(nameof(cityName));
            }

            var contain = context.PeakDays
                .Join(
                    context.Cities,
                    peak => peak.City.Id,
                    city => city.Id,
                    (peak, city) => new
                    {
                        CityName = city.Name,
                        CityPeakSeason = city.PeakSeason,
                        PeakBegin = peak.PeakBegin,
                        PeakEnd = peak.PeakEnd
                    }).Where(x => 
                            x.CityName == cityName && 
                            x.PeakBegin.Date <= date.Date && 
                            x.PeakEnd >= date.Date &&
                            x.CityPeakSeason == true).FirstOrDefault();

            if(contain == null)
            {
                return false;
            }
            return true;
        }

        public int MaxOfTheDayOffPeakSeason(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                throw new ArgumentNullException(nameof(cityName));
            }

            return context.Cities.Where(city => city.Name == cityName).Select(c => c.MaxDayOffPeakSeason).FirstOrDefault();
        }

        public int MaxOfDayPeakSeason(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                throw new ArgumentNullException(nameof(cityName));
            }

            return context.Cities.Where(city => city.Name == cityName).Select(c => c.MaxDayPeakSeason).FirstOrDefault();
        }

        public int ReturnTollFee(TimeSpan time, string cityName, bool peakDay)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                throw new ArgumentNullException(nameof(cityName));
            }

            return context.TaxAmounts
                .Join(
                    context.Cities,
                    tax => tax.City.Id,
                    city => city.Id,
                    (tax, city) => new
                    {
                        CityName = city.Name,
                        TimeIn = tax.TimeIn,
                        TimeOut = tax.TimeOut,
                        Amount = tax.Amount,
                        PeakSeason = tax.PeakSeason
                    }).Where(x => 
                            x.CityName == cityName && 
                            x.TimeIn <= time 
                            && (x.TimeOut == TimeSpan.Zero || x.TimeOut > time)
                            && x.PeakSeason == peakDay).First().Amount;
        }
    }
}
