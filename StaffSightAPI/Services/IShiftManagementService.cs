using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IShiftManagementService
    {
        Task<IEnumerable<Shift>> GetAllShiftsAsync();
        Task<Shift?> GetShiftByIdAsync(int id);
        Task<bool> AddShiftAsync(Shift shift);
        Task<bool> UpdateShiftAsync(Shift shift);
        Task<bool> DeleteShiftAsync(int id);
    }
}
