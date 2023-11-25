using Domain.Models;
using Domain.Models.Interfaces;

namespace AdminService.Services
{
    public class HouseholdDetailService : IHouseholdDetailService
    {
        private IHouseholdDetailAdapter _adapter;

        public HouseholdDetailService(IHouseholdDetailAdapter adapter)
        {
            _adapter = adapter;
        }
    }
}
