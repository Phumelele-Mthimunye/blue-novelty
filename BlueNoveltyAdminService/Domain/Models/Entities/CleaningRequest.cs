using Domain.Enums;
using Domain.Models.Dtos.CleaningRequest;
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

        [Column("customer_Id")]
        public Guid? CustomerId { get; set; }

        [ForeignKey("customerId")]
        public virtual Customer? Customer { get; set; }

        [Required]
        [Column("householdDetail_Id")]
        public Guid? HouseholdDetailId { get; set; }

        [ForeignKey("HouseholdDetailId")]
        public virtual HouseholdDetail? HouseholdDetail { get; set; }

        [Column("serviceProvider_Id")]
        public Guid? ServiceProviderId { get; set; }

        [ForeignKey("ServiceProviderId")]
        public virtual ServiceProvider? ServiceProvider { get; set; }

        public CleaningRequest() { }

        public CleaningRequest(CleaningRequestDTO request)
        {

        }
    }
}
