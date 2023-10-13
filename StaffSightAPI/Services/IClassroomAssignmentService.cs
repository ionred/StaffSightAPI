using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IClassroomAssignmentService
    {
        Task<IEnumerable<ClassroomAssignment>> GetAllClassroomAssignmentsAsync();
        Task<ClassroomAssignment?> GetClassroomAssignmentByIdAsync(int classroomAssignmentId);
        Task<bool> AddClassroomAssignmentAsync(ClassroomAssignment classroomAssignment);
        Task<bool> UpdateClassroomAssignmentAsync(ClassroomAssignment classroomAssignment);
        Task<bool> DeleteClassroomAssignmentAsync(int classroomAssignmentId);
    }
}
