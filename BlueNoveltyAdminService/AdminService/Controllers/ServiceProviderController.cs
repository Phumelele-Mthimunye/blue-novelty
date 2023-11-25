using Domain.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlueNoveltyAdminService.Controllers
{
    [Route("serviceProvider")]
    [ApiController]
    public class ServiceProviderController : Controller
    {
        private readonly IServiceProviderService _service;

        public ServiceProviderController(IServiceProviderService service) 
        {
            this._service = service;
        }
    }
}
