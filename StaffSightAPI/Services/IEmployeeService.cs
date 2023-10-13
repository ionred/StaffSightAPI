using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeePreHire>> GetAllEmployeesAsync();
        Task<EmployeePreHire?> GetEmployeeByIdAsync(int id);
        Task<bool> AddEmployeeAsync(EmployeePreHire employee);
        Task<bool> UpdateEmployeeAsync(EmployeePreHire employee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
