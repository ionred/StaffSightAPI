using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class ShiftManagementService : IShiftManagementService
    {
        private readonly IGenericRepository<Shift> _shiftRepository;

        public ShiftManagementService(IGenericRepository<Shift> shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        public async Task<IEnumerable<Shift>> GetAllShiftsAsync()
        {
            return await _shiftRepository.GetAllAsync();
        }

        public async Task<Shift?> GetShiftByIdAsync(int id)
        {
            return await _shiftRepository.GetByIdAsync(id);
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

        public async Task<bool> DeleteShiftAsync(int id)
        {
            var shift = await _shiftRepository.GetByIdAsync(id);
            if (shift == null) return false;

            _shiftRepository.Delete(shift);
            return await _shiftRepository.SaveAllAsync();
        }
    }
}
