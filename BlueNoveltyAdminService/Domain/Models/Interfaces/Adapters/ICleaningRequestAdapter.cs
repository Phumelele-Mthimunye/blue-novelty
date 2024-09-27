using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;

namespace Domain.Models.Interfaces.Adapters
{
    public interface ICleaningRequestAdapter
    {
        void Delete(DeleteDBRequest request);
        CleaningRequestDetailDTO Insert(CleaningRequestDTO request);
        List<CleaningRequestDetailDTO> Read(CleaningRequestDetailDTO request);
        CleaningRequestDetailDTO Update(CleaningRequestWithIdDTO request);
    }
}

