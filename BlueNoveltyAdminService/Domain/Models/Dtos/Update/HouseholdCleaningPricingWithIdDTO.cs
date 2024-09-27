using Domain.Models.Dtos.Create;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Domain.Models.Dtos.Update
{
    public class HouseholdCleaningPricingWithIdDTO : HouseholdCleaningPricingDTO
    {
        [DataMember(Name = "id")]
        [Required]
        public long Id { get; set; }
    }
}
