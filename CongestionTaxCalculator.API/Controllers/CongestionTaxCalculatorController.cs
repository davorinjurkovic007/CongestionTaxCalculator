using CongestionTaxCalculator.Data.Models;
using CongestionTaxCalculator.Helpers;
using CongestionTaxCalculator.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CongestionTaxCalculator.API.Controllers
{
    [ApiController]
    [Route("api/congestiontaxcalculator")]
    public class CongestionTaxCalculatorController : ControllerBase
    {
        private readonly IValidateInputData validateInputData;
        private readonly ICalculateTaxValue calculateTaxValue;

        public CongestionTaxCalculatorController(IValidateInputData validateInputData, ICalculateTaxValue calculateTaxValue)
        {
            this.validateInputData = validateInputData ?? throw new ArgumentNullException(nameof(validateInputData));
            this.calculateTaxValue = calculateTaxValue ?? throw new ArgumentNullException(nameof(calculateTaxValue));
        }

        /// <summary>
        /// Calculate the total toll fee for one day
        /// </summary>
        /// <param name="inputDataDto"></param>
        /// <returns>the total congestion tax for that day</returns>
        [HttpPost]
        public IActionResult CalculateTax(InputDataDto inputDataDto)
        {
            if(!validateInputData.ValidateData(inputDataDto))
            {
                return BadRequest();
            }

            var totalFee = calculateTaxValue.GetTax(inputDataDto);

            return Ok(new { TotalFee = totalFee });
        }
    }
}
