using Domain.Models.Entities;
using Domain.Models.Interfaces;
using SharedServices;

namespace AdminService.Adapter
{
    public class HouseholdDetailAdapter : IHouseholdDetailAdapter
    {
        private readonly IRepository<HouseholdDetail, Guid> _repo;

        public HouseholdDetailAdapter(IRepository<HouseholdDetail, Guid> repo)
        {
            _repo = repo;
        }

    }
}
