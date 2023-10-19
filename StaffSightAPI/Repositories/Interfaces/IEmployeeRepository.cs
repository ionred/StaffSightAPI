using StaffSightAPI.DTOs;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<EmployeePreHire>
    {
        Task<List<object>> GetMergedEmployees(int pageSize, int pageNumber, string sortBy, List<string> fields);
        Task<EmployeeDto> GetMergedEmployeeById(int? preHireID, string? empID);

    }
}
