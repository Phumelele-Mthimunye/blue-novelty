using Domain.Models;
using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;
using Domain.Models.Interfaces.Adapters;
using Domain.Models.Interfaces.Services;
using SharedServices.Enums;
using SharedServices;

namespace AdminService.Services
{
    public class ServiceService : IServiceService
    {
        private IServiceAdapter _adapter;

        public ServiceService(IServiceAdapter adapter)
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

        public GenericResponse<ServiceDetailDTO> Insert(ServiceDTO request)
        {
            try
            {
                var createResult = _adapter.Insert(request);
                return new GenericResponse<ServiceDetailDTO>(createResult);
            }
            catch (Exception ex)
            {
                return new GenericResponse<ServiceDetailDTO>(MessageOutcome.Failure);
            }
        }

        public GenericResponse<List<ServiceDetailDTO>> Read(ServiceDetailDTO request)
        {
            try
            {
                var readResults = _adapter.Read(request);
                return new GenericResponse<List<ServiceDetailDTO>>(readResults);
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<ServiceDetailDTO>>(MessageOutcome.Failure);
            }
        }

        public GenericResponse<ServiceDetailDTO> Update(ServiceWithIdDTO request)
        {
            try
            {
                var updateResult = _adapter.Update(request);
                return new GenericResponse<ServiceDetailDTO>(updateResult);
            }
            catch (Exception ex)
            {
                return new GenericResponse<ServiceDetailDTO>(MessageOutcome.Failure);
            }
        }
    }
}
