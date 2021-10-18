using CongestionTaxCalculator.Data.Models;
using CongestionTaxCalculator.Helpers;
using System;
using System.Collections.Generic;

namespace CongestionTaxCalculator.Services
{
    public class CalculateTaxValue : ICalculateTaxValue
    {
        private readonly ICongestionTaxCalculatorRepository congestionTaxCalculatorRepository;

        public CalculateTaxValue(ICongestionTaxCalculatorRepository congestionTaxCalculatorRepository)
        {
            this.congestionTaxCalculatorRepository = congestionTaxCalculatorRepository;
        }

        public int GetTax(InputDataDto inputDataDto)
        {
            if(inputDataDto == null)
            {
                throw new ArgumentNullException(nameof(inputDataDto));
            }

            if(TollFreeVehicles.CheckListOfFreeTollVehicles(inputDataDto.Vehicle))
            {
                return 0;
            }

            List<DateTime> dates = new List<DateTime>();
            ConvertArrayStringToListDateTime(inputDataDto.Dates, dates);
            dates.Sort((a, b) => a.CompareTo(b));

            if(CheckDate(dates, inputDataDto.City))
            {
                return 0;
            }

            var taxFee = GetTax(dates, inputDataDto.City);

            return taxFee;
        }

        private void ConvertArrayStringToListDateTime(string[] dates, List<DateTime> listOfDates)
        {
            foreach(var date in dates)
            {
                DateTime datetime;
                DateTime.TryParse(date, out datetime);
                listOfDates.Add(datetime);
            }
        }

        private bool CheckDate(List<DateTime> dates, string city)
        {
            DateTime dateTime = dates[0];

            if(dateTime.Year.ToString() != "2013")
            {
                return true;
            }

            if(dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            if (congestionTaxCalculatorRepository.IsFreOfChargeDay(dateTime, city))
            {
                return true;
            }

            return false;
        }

        private int GetTax(List<DateTime> dates, string city)
        {
            DateTime intervalStart = dates[0];
            int totalFee = 0;
            int maxFeePerDay = GetMaxFeePerDay(intervalStart, city);

            foreach (DateTime date in dates)
            {
                if(intervalStart.Date != date.Date)
                {
                    return totalFee;
                }

                int nextFee = GetTooFee(date, city);

                if(congestionTaxCalculatorRepository.IsSingleChargeRule(city))
                {
                    int tempFee = GetTooFee(intervalStart, city);

                    TimeSpan diffInMillies = date - intervalStart;
                    long miliseconds = (long)diffInMillies.TotalMilliseconds;
                    long minutes = miliseconds / 1000 / 60;

                    if(minutes <= 60)
                    {
                        if (totalFee > 0) totalFee -= tempFee;
                        if (nextFee >= tempFee) tempFee = nextFee;
                        totalFee += tempFee;
                    }
                    else
                    {
                        totalFee += nextFee;
                        intervalStart = date;
                    }

                    if (totalFee > maxFeePerDay)
                    {
                        totalFee = maxFeePerDay;
                    }
                }
                else
                {
                    totalFee += nextFee;
                    if(totalFee > maxFeePerDay)
                    {
                        totalFee = maxFeePerDay;
                    }
                }
            }

            return totalFee;
        }

        private int GetTooFee(DateTime date, string city)
        {
            int hour = date.Hour;
            int minute = date.Minute;

            TimeSpan time = new TimeSpan(hour, minute, 0);

            bool peakSeason = congestionTaxCalculatorRepository.IsPeakSeason(date, city);

            return congestionTaxCalculatorRepository.ReturnTollFee(time, city, peakSeason);
        }

        private int GetMaxFeePerDay(DateTime date, string city)
        {
            bool peakSeason = congestionTaxCalculatorRepository.IsPeakSeason(date, city);

            if (peakSeason)
            {
                return congestionTaxCalculatorRepository.MaxOfDayPeakSeason(city);
            }
            else
            {
                return congestionTaxCalculatorRepository.MaxOfTheDayOffPeakSeason(city);
            }
        }
    }
}
