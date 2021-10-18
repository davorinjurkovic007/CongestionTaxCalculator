using CongestionTaxCalculator.Data.Models;

namespace CongestionTaxCalculator.Helpers
{
    public interface IValidateInputData
    {
        bool ValidateData(InputDataDto inputDataDto);
    }
}
