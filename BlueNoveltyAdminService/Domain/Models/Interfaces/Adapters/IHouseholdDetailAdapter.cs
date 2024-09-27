using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;

namespace Domain.Models.Interfaces.Adapters
{
    public interface IHouseholdDetailAdapter
    {
        void Delete(DeleteDBRequest request);
        HouseholdDetailDetailDTO Insert(HouseholdDetailDTO request);
        List<HouseholdDetailDetailDTO> Read(HouseholdDetailDetailDTO request);
        HouseholdDetailDetailDTO Update(HouseholdDetailWithIdDTO request);
    }
}

