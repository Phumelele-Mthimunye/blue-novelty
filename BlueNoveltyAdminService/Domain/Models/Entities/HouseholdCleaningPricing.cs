using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    [Table("HouseholdCleaningPricings")]
    public class HouseholdCleaningPricing : BaseEntity
    {
        [Required]
        [Column("room")]
        public string Room { get; set; }

        [Required]
        [Column("roomServiceDescription")]
        public string RoomServiceDescription { get; set; }

        [Required]
        [Column("price")]
        public decimal? Price { get; set; }
    }
}
