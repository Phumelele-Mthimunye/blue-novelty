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
    [Route("household-detail")]
    public class HouseholdDetailController : ControllerBase
    {
        private readonly IHouseholdDetailService _service;

        public HouseholdDetailController(IHouseholdDetailService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("insert")]
        public GenericResponse<HouseholdDetailDetailDTO> InsertHouseholdDetail([FromBody] GenericRequest<HouseholdDetailDTO> request)
        {
            return _service.Insert(request.Data);
        }

        [HttpPost]
        [Route("update")]
        public GenericResponse<HouseholdDetailDetailDTO> UpdateHouseholdDetail([FromBody] GenericRequest<HouseholdDetailWithIdDTO> request)
        {
            return _service.Update(request.Data);
        }

        [HttpPost]
        [Route("delete")]
        public GenericResponse<string> DeleteHouseholdDetail([FromBody] GenericRequest<DeleteDBRequest> request)
        {
            return _service.Delete(request.Data);
        }

        [HttpPost]
        [Route("read")]
        public GenericResponse<List<HouseholdDetailDetailDTO>> ReadHouseholdDetail([FromBody] GenericRequest<HouseholdDetailDetailDTO> request)
        {
            return _service.Read(request.Data);
        }
    }
}

