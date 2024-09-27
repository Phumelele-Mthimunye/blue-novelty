using Domain.Models.Dtos;
using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;
using Domain.Models.Entities;
using SharedServices;

namespace Domain.Models.Interfaces.Services
{
    public interface IServiceService
    {
        GenericResponse<string> Delete(DeleteDBRequest request);
        GenericResponse<ServiceDetailDTO> Insert(ServiceDTO request);
        GenericResponse<List<ServiceDetailDTO>> Read(ServiceDetailDTO request);
        GenericResponse<ServiceDetailDTO> Update(ServiceWithIdDTO request);
    }
}
