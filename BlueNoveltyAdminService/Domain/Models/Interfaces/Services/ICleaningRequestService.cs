using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;
using SharedServices;

namespace Domain.Models.Interfaces.Services
{
    public interface ICleaningRequestService
    {
        GenericResponse<string> Delete(DeleteDBRequest request);
        GenericResponse<CleaningRequestDetailDTO> Insert(CleaningRequestDTO request);
        GenericResponse<List<CleaningRequestDetailDTO>> Read(CleaningRequestDetailDTO request);
        GenericResponse<CleaningRequestDetailDTO> Update(CleaningRequestWithIdDTO request);
    }
}

