using System.ComponentModel.DataAnnotations;

namespace CongestionTaxCalculator.Models.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool SingleChargeRule { get; set; }
        public bool PeakSeason { get; set; }
        public int MaxDayOffPeakSeason { get; set; }
        public int MaxDayPeakSeason { get; set; }
    }
}
