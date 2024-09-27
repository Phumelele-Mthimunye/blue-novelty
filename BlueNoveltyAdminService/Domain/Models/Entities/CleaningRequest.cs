using Domain.Enums;
using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    [Table("CleaningRequests")]
    public class CleaningRequest : BaseEntity
    {
        [Required]
        [Column("dateOfRequest")]
        public DateTime? DateOfRequest { get; set; }

        [Required]
        [Column("status")]
        public Status? Status { get; set; }

        [Required]
        [Column("totalPrice")]
        public decimal? TotalPrice { get; set; }

        [Column("customer_Id")]
        public long? CustomerId { get; set; }

        [ForeignKey("customerId")]
        public virtual Customer? Customer { get; set; }

        [Required]
        [Column("householdDetail_Id")]
        public long? HouseholdDetailId { get; set; }

        [ForeignKey("HouseholdDetailId")]
        public virtual HouseholdDetail? HouseholdDetail { get; set; }

        [Column("serviceProvider_Id")]
        public long? ServiceProviderId { get; set; }

        [ForeignKey("ServiceProviderId")]
        public virtual ServiceProvider? ServiceProvider { get; set; }

        public CleaningRequest() { }

        public CleaningRequest(CleaningRequestDTO request)
        {

        }

        public CleaningRequestDetailDTO ToDto()
        {
            return new CleaningRequestDetailDTO()
            {

            };
        }

        public void MapUpdateValues(CleaningRequestWithIdDTO request)
        {
            
        }
    }
}
