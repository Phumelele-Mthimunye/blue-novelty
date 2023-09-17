using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    [Table("CleaningRequests")]
    public class CleaningRequest : BaseEntity
    {
        [Required]
        [Column("dateOfRequest")]
        public DateOnly? DateOfRequest { get; set; }

        [Required]
        [Column("status")]
        public Status? Status { get; set; }

        [Required]
        [Column("totalPrice")]
        public decimal? TotalPrice { get; set; }

        [Column("user_Id")]
        public Guid? UserId { get; set; }

        [ForeignKey("userId")]
        public virtual User? User { get; set; }

        [Required]
        [Column("householdDetail_Id")]
        public Guid? HouseholdDetailId { get; set; }

        [ForeignKey("HouseholdDetailId")]
        public virtual HouseholdDetail? HouseholdDetail { get; set; }
    }
}
