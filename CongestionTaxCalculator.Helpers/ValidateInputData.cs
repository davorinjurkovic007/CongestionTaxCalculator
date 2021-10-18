using CongestionTaxCalculator.Data.Models;
using CongestionTaxCalculator.Services;
using System;

namespace CongestionTaxCalculator.Helpers
{
    public class ValidateInputData : IValidateInputData
    {
        private readonly ICongestionTaxCalculatorRepository congestionTaxCalculatorRepository;

        public ValidateInputData(ICongestionTaxCalculatorRepository congestionTaxCalculatorRepository)
        {
            this.congestionTaxCalculatorRepository = congestionTaxCalculatorRepository ?? throw new ArgumentNullException(nameof(congestionTaxCalculatorRepository));
        }

        public bool ValidateData(InputDataDto inputDataDto)
        {
            if (!congestionTaxCalculatorRepository.CityExist(inputDataDto.City))
            {
                return false;
            }

            foreach(var dates in inputDataDto.Dates)
            {
                DateTime dateValue;
                if(!DateTime.TryParse(dates, out dateValue))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
