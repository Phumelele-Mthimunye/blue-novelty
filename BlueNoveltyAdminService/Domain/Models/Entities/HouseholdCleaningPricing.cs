using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    [Table("HouseholdCleaningPricings")]
    public class HouseholdCleaningPricing : BaseEntity
    {
        [Required]
        [Column("cleaningTask")]
        public string? CleaningTask { get; set; }

        [Column("cleaningTaskDescription")]
        public string? CleaningTaskDescription { get; set; }

        [Required]
        [Column("price")]
        public decimal? Price { get; set; }
    }
}
