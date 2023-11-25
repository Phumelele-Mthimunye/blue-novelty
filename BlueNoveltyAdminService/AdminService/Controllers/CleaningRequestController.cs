using Domain.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlueNoveltyAdminService.Controllers
{
    [Route("cleaningRequest")]
    [ApiController]
    public class CleaningRequestController : Controller
    {
        private readonly ICleaningRequestService _service;

        public CleaningRequestController(ICleaningRequestService service) 
        {
            this._service = service;
        }
    }
}
