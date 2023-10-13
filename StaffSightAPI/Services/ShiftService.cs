using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IGenericRepository<Shift> _shiftRepository;

        public ShiftService(IGenericRepository<Shift> shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        public async Task<IEnumerable<Shift>> GetAllShiftsAsync()
        {
            return await _shiftRepository.GetAllAsync();
        }

        public async Task<Shift?> GetShiftByIdAsync(int shiftId)
        {
            return await _shiftRepository.GetByIdAsync(shiftId);
        }

        public async Task<bool> AddShiftAsync(Shift shift)
        {
            await _shiftRepository.AddAsync(shift);
            return await _shiftRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateShiftAsync(Shift shift)
        {
            _shiftRepository.Update(shift);
            return await _shiftRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteShiftAsync(int shiftId)
        {
            var shift = await _shiftRepository.GetByIdAsync(shiftId);
            if (shift == null) return false;
            
            _shiftRepository.Delete(shift);
            return await _shiftRepository.SaveAllAsync();
        }
    }
}
