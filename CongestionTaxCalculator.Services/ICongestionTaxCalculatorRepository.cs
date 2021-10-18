using System;

namespace CongestionTaxCalculator.Services
{
    public interface ICongestionTaxCalculatorRepository
    {
        bool CityExist(string cityName);
        bool IsFreOfChargeDay(DateTime date, string city);
        bool IsSingleChargeRule(string cityName);
        bool IsPeakSeason(DateTime date, string cityName);
        int MaxOfTheDayOffPeakSeason(string cityName);
        int MaxOfDayPeakSeason(string cityName);
        int ReturnTollFee(TimeSpan time, string cityName, bool peakDay);
    }
}
