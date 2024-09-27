using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;
using Domain.Models.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using SharedServices;

namespace BlueNoveltyAdminService.Controllers
{
    [Route("service")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService service) 
        {
            this._service = service;
        }

        [HttpPost]
        [Route("insert")]
        public GenericResponse<ServiceDetailDTO> InsertService([FromBody] GenericRequest<ServiceDTO> request)
        {
            return _service.Insert(request.Data);
        }

        [HttpPost]
        [Route("update")]
        public GenericResponse<ServiceDetailDTO> UpdateService([FromBody] GenericRequest<ServiceWithIdDTO> request)
        {
            return _service.Update(request.Data);
        }

        [HttpPost]
        [Route("delete")]
        public GenericResponse<string> DeleteService([FromBody] GenericRequest<DeleteDBRequest> request)
        {
            return _service.Delete(request.Data);
        }

        [HttpPost]
        [Route("read")]
        public GenericResponse<List<ServiceDetailDTO>> ReadService([FromBody] GenericRequest<ServiceDetailDTO> request)
        {
            return _service.Read(request.Data);
        }
    }
}
