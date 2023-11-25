using Domain.Models.Entities;
using Domain.Models.Interfaces;
using SharedServices;

namespace AdminService.Adapter
{
    public class CleaningRequestAdapter : ICleaningRequestAdapter
    {
        private readonly IRepository<CleaningRequest, Guid> _repo;

        public CleaningRequestAdapter(IRepository<CleaningRequest, Guid> repo)
        {
            _repo = repo;
        }

    }
}
