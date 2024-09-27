using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;
using Domain.Models.Interfaces.Adapters;
using Domain.Models.Interfaces.Services;
using SharedServices;
using SharedServices.Enums;

namespace AdminService.Services
{
    public class CleaningRequestService : ICleaningRequestService
    {
        private readonly ICleaningRequestAdapter _adapter;

        public CleaningRequestService(ICleaningRequestAdapter adapter)
        {
            _adapter = adapter;
        }

        public GenericResponse<string> Delete(DeleteDBRequest request)
        {
            try
            {
                _adapter.Delete(request);
                return new GenericResponse<string>(MessageOutcome.Success);
            }
            catch (Exception ex)
            {
                return new GenericResponse<string>(MessageOutcome.Failure);
            }
        }

        public GenericResponse<CleaningRequestDetailDTO> Insert(CleaningRequestDTO request)
        {
            try
            {
                var createResult = _adapter.Insert(request);
                return new GenericResponse<CleaningRequestDetailDTO>(createResult);
            }
            catch (Exception ex)
            {
                return new GenericResponse<CleaningRequestDetailDTO>(MessageOutcome.Failure);
            }
        }

        public GenericResponse<List<CleaningRequestDetailDTO>> Read(CleaningRequestDetailDTO request)
        {
            try
            {
                var readResults = _adapter.Read(request);
                return new GenericResponse<List<CleaningRequestDetailDTO>>(readResults);
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<CleaningRequestDetailDTO>>(MessageOutcome.Failure);
            }
        }

        public GenericResponse<CleaningRequestDetailDTO> Update(CleaningRequestWithIdDTO request)
        {
            try
            {
                var updateResult = _adapter.Update(request);
                return new GenericResponse<CleaningRequestDetailDTO>(updateResult);
            }
            catch (Exception ex)
            {
                return new GenericResponse<CleaningRequestDetailDTO>(MessageOutcome.Failure);
            }
        }
    }
}
