using Domain.Models.Entities;
using Domain.Models.Interfaces;
using SharedServices;
using ServiceProvider = Domain.Models.Entities.ServiceProvider;

namespace AdminService.Adapter
{
    public class ServiceProviderAdapter : IServiceProviderAdapter
    {
        private readonly IRepository<ServiceProvider, Guid> _repo;

        public ServiceProviderAdapter(IRepository<ServiceProvider, Guid> repo)
        {
            _repo = repo;
        }

    }
}
