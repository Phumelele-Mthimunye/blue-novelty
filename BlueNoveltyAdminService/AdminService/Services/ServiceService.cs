using Domain.Models;
using Domain.Models.Interfaces;

namespace AdminService.Services
{
    public class ServiceService : IServiceService
    {
        private IServiceAdapter _adapter;

        public ServiceService(IServiceAdapter adapter)
        {
            _adapter = adapter;
        }
    }
}
