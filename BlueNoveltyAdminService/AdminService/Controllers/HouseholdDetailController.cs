using Domain.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlueNoveltyAdminService.Controllers
{
    [Route("householdDetail")]
    [ApiController]
    public class HouseholdDetailController : Controller
    {
        private readonly IHouseholdDetailService _service;

        public HouseholdDetailController(IHouseholdDetailService service) 
        {
            this._service = service;
        }
    }
}
