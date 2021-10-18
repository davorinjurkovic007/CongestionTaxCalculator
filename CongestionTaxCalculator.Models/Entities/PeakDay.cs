using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongestionTaxCalculator.Models.Entities
{
    public class PeakDay
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public DateTime PeakBegin { get; set; }
        public DateTime PeakEnd { get; set; }

        public City City { get; set; }
    }
}
