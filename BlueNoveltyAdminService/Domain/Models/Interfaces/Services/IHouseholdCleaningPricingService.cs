using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;
using SharedServices;

namespace Domain.Models.Interfaces.Services
{
    public interface IHouseholdCleaningPricingService
    {
        GenericResponse<string> Delete(DeleteDBRequest request);
        GenericResponse<HouseholdCleaningPricingDetailDTO> Insert(HouseholdCleaningPricingDTO request);
        GenericResponse<List<HouseholdCleaningPricingDetailDTO>> Read(HouseholdCleaningPricingDetailDTO request);
        GenericResponse<HouseholdCleaningPricingDetailDTO> Update(HouseholdCleaningPricingWithIdDTO request);
    }
}

