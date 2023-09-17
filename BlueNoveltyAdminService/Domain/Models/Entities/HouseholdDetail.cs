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
        public int NumberOfBedrooms { get; set; }

        [Required]
        [Column("numberOfBathrooms")]
        public int NumberOfBathrooms { get; set; }

        [Required]
        [Column("numberOfAdditionalRooms")]
        public int NumberOfAdditionalRooms { get; set; }

        public virtual List<CleaningRequest>? CleaningRequests { get; set; }
    }
}
