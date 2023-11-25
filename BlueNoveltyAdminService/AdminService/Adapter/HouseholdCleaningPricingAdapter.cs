using Domain.Models.Entities;
using Domain.Models.Interfaces;
using SharedServices;

namespace AdminService.Adapter
{
    public class HouseholdCleaningPricingAdapter : IHouseholdCleaningPricingAdapter
    {
        private readonly IRepository<HouseholdCleaningPricing, Guid> _repo;

        public HouseholdCleaningPricingAdapter(IRepository<HouseholdCleaningPricing, Guid> repo)
        {
            _repo = repo;
        }


    }
}
