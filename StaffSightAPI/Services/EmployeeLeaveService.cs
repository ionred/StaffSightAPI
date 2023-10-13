using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class EmployeeLeaveService : IEmployeeLeaveService
    {
        private readonly IGenericRepository<EmployeeLeave> _leaveRepository;

        public EmployeeLeaveService(IGenericRepository<EmployeeLeave> leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        public async Task<IEnumerable<EmployeeLeave>> GetAllLeavesAsync()
        {
            return await _leaveRepository.GetAllAsync();
        }

        public async Task<EmployeeLeave?> GetLeaveByIdAsync(int id)
        {
            return await _leaveRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddLeaveAsync(EmployeeLeave leave)
        {
            await _leaveRepository.AddAsync(leave);
            return await _leaveRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateLeaveAsync(EmployeeLeave leave)
        {
            _leaveRepository.Update(leave);
            return await _leaveRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteLeaveAsync(int id)
        {
            var leave = await _leaveRepository.GetByIdAsync(id);
            if (leave == null) return false;

            _leaveRepository.Delete(leave);
            return await _leaveRepository.SaveAllAsync();
        }
    }
}
