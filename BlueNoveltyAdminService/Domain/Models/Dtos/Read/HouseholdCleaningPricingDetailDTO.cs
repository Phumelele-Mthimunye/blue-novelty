using Domain.Models.Dtos.Update;
using System.Runtime.Serialization;

namespace Domain.Models.Dtos.Read
{
    public class HouseholdCleaningPricingDetailDTO : HouseholdCleaningPricingWithIdDTO
    {
        [DataMember(Name = "active")]
        public bool Active { get; set; }
    }
}
