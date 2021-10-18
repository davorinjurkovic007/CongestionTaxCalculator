using System.ComponentModel.DataAnnotations;

namespace CongestionTaxCalculator.Data.Models
{
    public class InputDataDto
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string Vehicle { get; set; }
        [Required]
        public string[] Dates { get; set; }
    }
}
