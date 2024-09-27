using Domain.Models.Dtos;
using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;
using Domain.Models.Entities;

namespace Domain.Models.Interfaces.Adapters
{
    public interface IServiceAdapter
    {
        void Delete(DeleteDBRequest request);
        ServiceDetailDTO Insert(ServiceDTO request);
        List<ServiceDetailDTO> Read(ServiceDetailDTO request);
        ServiceDetailDTO Update(ServiceWithIdDTO request);
    }
}
