using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.DTOs;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IEmployeeService
    {
        //Task<IEnumerable<EmployeePreHire>> GetAllEmployeesAsync();
        //Task<EmployeePreHire> GetEmployeeByIdAsync(int id);
        //Task AddEmployeeAsync(EmployeePreHire employee);
        //Task UpdateEmployeeAsync(EmployeePreHire employee);
        //Task DeleteEmployeeAsync(int id);
        Task<List<object>> GetMergedEmployees(int pageSize, int pageNumber, string sortBy, List<string> fields);
        Task<EmployeeDto> GetMergedEmployeeById(int? preHireID, string? empID);

    }
}
