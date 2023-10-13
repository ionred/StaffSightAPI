using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class ClassAttendanceService : IClassAttendanceService
    {
        private readonly IGenericRepository<ClassAttendance> _classAttendanceRepository;

        public ClassAttendanceService(IGenericRepository<ClassAttendance> classAttendanceRepository)
        {
            _classAttendanceRepository = classAttendanceRepository;
        }

        public async Task<IEnumerable<ClassAttendance>> GetAllClassAttendancesAsync()
        {
            return await _classAttendanceRepository.GetAllAsync();
        }

        public async Task<ClassAttendance?> GetClassAttendanceByIdAsync(int classAttendanceId)
        {
            return await _classAttendanceRepository.GetByIdAsync(classAttendanceId);
        }

        public async Task<bool> AddClassAttendanceAsync(ClassAttendance classAttendance)
        {
            await _classAttendanceRepository.AddAsync(classAttendance);
            return await _classAttendanceRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateClassAttendanceAsync(ClassAttendance classAttendance)
        {
            _classAttendanceRepository.Update(classAttendance);
            return await _classAttendanceRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteClassAttendanceAsync(int classAttendanceId)
        {
            var classAttendance = await _classAttendanceRepository.GetByIdAsync(classAttendanceId);
            if (classAttendance == null) return false;
            
            _classAttendanceRepository.Delete(classAttendance);
            return await _classAttendanceRepository.SaveAllAsync();
        }
    }
}
