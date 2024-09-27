using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;

namespace Domain.Models.Interfaces.Adapters
{
    public interface IHouseholdCleaningPricingAdapter
    {
        void Delete(DeleteDBRequest request);
        HouseholdCleaningPricingDetailDTO Insert(HouseholdCleaningPricingDTO request);
        List<HouseholdCleaningPricingDetailDTO> Read(HouseholdCleaningPricingDetailDTO request);
        HouseholdCleaningPricingDetailDTO Update(HouseholdCleaningPricingWithIdDTO request);
    }
}

