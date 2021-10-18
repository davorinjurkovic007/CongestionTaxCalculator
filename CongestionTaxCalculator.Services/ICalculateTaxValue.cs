using CongestionTaxCalculator.Data.Models;

namespace CongestionTaxCalculator.Services
{
    public interface ICalculateTaxValue
    {
        int GetTax(InputDataDto inputDataDto);
    }
}
