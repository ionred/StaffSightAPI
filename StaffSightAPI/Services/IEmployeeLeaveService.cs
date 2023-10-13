using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IEmployeeLeaveService
    {
        Task<IEnumerable<EmployeeLeave>> GetAllLeavesAsync();
        Task<EmployeeLeave?> GetLeaveByIdAsync(int id);
        Task<bool> AddLeaveAsync(EmployeeLeave leave);
        Task<bool> UpdateLeaveAsync(EmployeeLeave leave);
        Task<bool> DeleteLeaveAsync(int id);
    }
}
