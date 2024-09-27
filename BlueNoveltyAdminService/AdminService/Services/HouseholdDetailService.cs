using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Delete;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;
using Domain.Models.Interfaces.Adapters;
using Domain.Models.Interfaces.Services;
using SharedServices;
using SharedServices.Enums;

namespace AdminService.Services
{
    public class HouseholdDetailService : IHouseholdDetailService
    {
        private readonly IHouseholdDetailAdapter _adapter;

        public HouseholdDetailService(IHouseholdDetailAdapter adapter)
        {
            _adapter = adapter;
        }

        public GenericResponse<string> Delete(DeleteDBRequest request)
        {
            try
            {
                _adapter.Delete(request);
                return new GenericResponse<string>(MessageOutcome.Success);
            }
            catch (Exception ex)
            {
                return new GenericResponse<string>(MessageOutcome.Failure);
            }
        }

        public GenericResponse<HouseholdDetailDetailDTO> Insert(HouseholdDetailDTO request)
        {
            try
            {
                var createResult = _adapter.Insert(request);
                return new GenericResponse<HouseholdDetailDetailDTO>(createResult);
            }
            catch (Exception ex)
            {
                return new GenericResponse<HouseholdDetailDetailDTO>(MessageOutcome.Failure);
            }
        }

        public GenericResponse<List<HouseholdDetailDetailDTO>> Read(HouseholdDetailDetailDTO request)
        {
            try
            {
                var readResults = _adapter.Read(request);
                return new GenericResponse<List<HouseholdDetailDetailDTO>>(readResults);
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<HouseholdDetailDetailDTO>>(MessageOutcome.Failure);
            }
        }

        public GenericResponse<HouseholdDetailDetailDTO> Update(HouseholdDetailWithIdDTO request)
        {
            try
            {
                var updateResult = _adapter.Update(request);
                return new GenericResponse<HouseholdDetailDetailDTO>(updateResult);
            }
            catch (Exception ex)
            {
                return new GenericResponse<HouseholdDetailDetailDTO>(MessageOutcome.Failure);
            }
        }
    }
}
