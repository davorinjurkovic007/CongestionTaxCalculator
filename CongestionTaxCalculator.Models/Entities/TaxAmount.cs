using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongestionTaxCalculator.Models.Entities
{
    public class TaxAmount
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }
        public int Amount { get; set; }
        public bool PeakSeason { get; set; }


        public City City { get; set; }
    }
}
