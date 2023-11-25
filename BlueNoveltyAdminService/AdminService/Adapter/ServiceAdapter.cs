using Domain.Models.Entities;
using Domain.Models.Interfaces;
using SharedServices;

namespace AdminService.Adapter
{
    public class ServiceAdapter : IServiceAdapter
    {
        private readonly IRepository<Service, Guid> _repo;

        public ServiceAdapter(IRepository<Service, Guid> repo)
        {
            _repo = repo;
        }

    }
}
