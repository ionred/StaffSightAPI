using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IPreFillService
    {
        Task<IEnumerable<EmployeeDM>> GetSupervisors();
        Task<IEnumerable<string>> GetDistinctBilletNumbers();
        Task<IEnumerable<Location>> GetDistinctLocations();
        Task<IEnumerable<GenericDefinition>> GetVendors();
        Task<IEnumerable<GenericDefinition>> GetISPs();
        // ... any other methods
    }

}
