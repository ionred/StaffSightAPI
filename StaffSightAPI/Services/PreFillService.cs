using StaffSightAPI.Models;
using StaffSightAPI.Repositories;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class PreFillService : IPreFillService
    {
        private readonly IPreFillRepository _preFillRepository;


        public PreFillService(IPreFillRepository preFillRepository)
        {
            _preFillRepository = preFillRepository;
        }

        public async Task<IEnumerable<EmployeeDM>> GetSupervisors()
        {
            return await _preFillRepository.GetSupervisors();
        }

        public async Task<IEnumerable<string>> GetDistinctBilletNumbers()
        {
            return await _preFillRepository.GetDistinctBilletNumbers();
        }

        public async Task<IEnumerable<Location>> GetDistinctLocations()
        {
            return await _preFillRepository.GetDistinctLocations();
        }

        public async Task<IEnumerable<GenericDefinition>> GetVendors()
        {
            return await _preFillRepository.GetVendors();
        }

        public async Task<IEnumerable<GenericDefinition>> GetISPs()
        {
            return await _preFillRepository.GetISPs();
        }
    }

}
