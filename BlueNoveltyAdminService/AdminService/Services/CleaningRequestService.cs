using Domain.Models;
using Domain.Models.Interfaces;

namespace AdminService.Services
{
    public class CleaningRequestService : ICleaningRequestService
    {
        private ICleaningRequestAdapter _adapter;

        public CleaningRequestService(ICleaningRequestAdapter adapter)
        {
            _adapter = adapter;
        }
    }
}
