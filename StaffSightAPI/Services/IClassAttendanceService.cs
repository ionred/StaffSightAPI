using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IClassAttendanceService
    {
        Task<IEnumerable<ClassAttendance>> GetAllClassAttendancesAsync();
        Task<ClassAttendance?> GetClassAttendanceByIdAsync(int classAttendanceId);
        Task<bool> AddClassAttendanceAsync(ClassAttendance classAttendance);
        Task<bool> UpdateClassAttendanceAsync(ClassAttendance classAttendance);
        Task<bool> DeleteClassAttendanceAsync(int classAttendanceId);
    }
}
