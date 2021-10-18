using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongestionTaxCalculator.Models.Entities
{
    public class FreeOfChargeDay
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public DateTime Date { get; set; }

        public City City { get; set; }
    }
}
