using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeePreHire>> GetEmployeesAsync(int pageNumber, int pageSize, string sortBy, string sortOrder, string fields);

        Task<EmployeePreHire?> GetEmployeeByIdAsync(string empID);
        Task<bool> AddEmployeeAsync(EmployeePreHire employee);
        Task<bool> UpdateEmployeeAsync(EmployeePreHire employee);
        Task DeleteEmployeeAsync(string empID);

    }
}
