using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;
using SharedServices;

namespace Domain.Models.Interfaces.Services
{
    public interface IHouseholdDetailService
    {
        GenericResponse<string> Delete(DeleteDBRequest request);
        GenericResponse<HouseholdDetailDetailDTO> Insert(HouseholdDetailDTO request);
        GenericResponse<List<HouseholdDetailDetailDTO>> Read(HouseholdDetailDetailDTO request);
        GenericResponse<HouseholdDetailDetailDTO> Update(HouseholdDetailWithIdDTO request);
    }
}

