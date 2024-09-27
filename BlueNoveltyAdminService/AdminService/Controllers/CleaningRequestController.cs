using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;
using Domain.Models.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using SharedServices;

namespace AdminService.Controllers
{
    [ApiController]
    //[ValidateController]
    [Route("cleaning-request")]
    public class CleaningRequestController : ControllerBase
    {
        private readonly ICleaningRequestService _service;

        public CleaningRequestController(ICleaningRequestService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("insert")]
        public GenericResponse<CleaningRequestDetailDTO> InsertCleaningRequest([FromBody] GenericRequest<CleaningRequestDTO> request)
        {
            return _service.Insert(request.Data);
        }

        [HttpPost]
        [Route("update")]
        public GenericResponse<CleaningRequestDetailDTO> UpdateCleaningRequest([FromBody] GenericRequest<CleaningRequestWithIdDTO> request)
        {
            return _service.Update(request.Data);
        }

        [HttpPost]
        [Route("delete")]
        public GenericResponse<string> DeleteCleaningRequest([FromBody] GenericRequest<DeleteDBRequest> request)
        {
            return _service.Delete(request.Data);
        }

        [HttpPost]
        [Route("read")]
        public GenericResponse<List<CleaningRequestDetailDTO>> ReadCleaningRequest([FromBody] GenericRequest<CleaningRequestDetailDTO> request)
        {
            return _service.Read(request.Data);
        }
    }
}

