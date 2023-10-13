using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IShiftService
    {
        Task<IEnumerable<Shift>> GetAllShiftsAsync();
        Task<Shift?> GetShiftByIdAsync(int shiftId);
        Task<bool> AddShiftAsync(Shift shift);
        Task<bool> UpdateShiftAsync(Shift shift);
        Task<bool> DeleteShiftAsync(int shiftId);
    }
}
