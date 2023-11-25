using Domain.Models;
using Domain.Models.Interfaces;

namespace AdminService.Services
{
    public class HouseholdCleaningPricingService : IHouseholdCleaningPricingService
    {
        private IHouseholdCleaningPricingAdapter _adapter;

        public HouseholdCleaningPricingService(IHouseholdCleaningPricingAdapter adapter)
        {
            _adapter = adapter;
        }
    }
}
