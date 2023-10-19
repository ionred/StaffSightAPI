using StaffSightAPI.Models;

namespace StaffSightAPI.Repositories.Interfaces
{
    public interface IPreFillRepository
    {
        Task<IEnumerable<EmployeeDM>> GetSupervisors();
        Task<IEnumerable<string>> GetDistinctBilletNumbers();
        Task<IEnumerable<Location>> GetDistinctLocations();
        Task<IEnumerable<GenericDefinition>> GetVendors();
        Task<IEnumerable<GenericDefinition>> GetISPs();
        // ... any other methods
    }

}
