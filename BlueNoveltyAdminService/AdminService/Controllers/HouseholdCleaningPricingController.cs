using Domain.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlueNoveltyAdminService.Controllers
{
    [Route("householdCleaningPricing")]
    [ApiController]
    public class HouseholdCleaningPricingController : Controller
    {
        private readonly IHouseholdCleaningPricingService _service;

        public HouseholdCleaningPricingController(IHouseholdCleaningPricingService service) 
        {
            this._service = service;
        }
    }
}
