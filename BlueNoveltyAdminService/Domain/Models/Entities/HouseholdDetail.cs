using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    [Table("HouseholdDetails")]
    public class HouseholdDetail : BaseEntity
    {
        [Required]
        [Column("numberOfBedrooms")]
        public int? NumberOfBedrooms { get; set; }

        [Required]
        [Column("numberOfBathrooms")]
        public int? NumberOfBathrooms { get; set; }

        [Required]
        [Column("laundry")]
        public bool? Laundry { get; set; }

        [Required]
        [Column("fridge")]
        public bool? Fridge { get; set; }

        [Required]
        [Column("garage")]
        public bool? Garage { get; set; }

        [Required]
        [Column("cabinets")]
        public bool? Cabinets { get; set; }

        [Required]
        [Column("windows")]
        public bool? Windows { get; set; }

        [Required]
        [Column("walls")]
        public bool? Walls { get; set; }

        public virtual List<CleaningRequest>? CleaningRequests { get; set; }
    }
}
