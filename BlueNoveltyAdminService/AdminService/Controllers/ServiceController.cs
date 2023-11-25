using Domain.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}
