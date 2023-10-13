using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IEmployeeSalOffHistService
    {
        Task<IEnumerable<EmployeeSalOffHist>> GetAllSalariesAsync();
        Task<EmployeeSalOffHist?> GetSalaryByIdAsync(int id);
        Task<bool> AddSalaryAsync(EmployeeSalOffHist salary);
        Task<bool> UpdateSalaryAsync(EmployeeSalOffHist salary);
        Task<bool> DeleteSalaryAsync(int id);
    }
}
