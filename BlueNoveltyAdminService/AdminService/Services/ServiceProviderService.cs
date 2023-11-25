using Domain.Models;
using Domain.Models.Interfaces;

namespace AdminService.Services
{
    public class ServiceProviderService : IServiceProviderService
    {
        private IServiceProviderAdapter _adapter;

        public ServiceProviderService(IServiceProviderAdapter adapter)
        {
            _adapter = adapter;
        }
    }
}
