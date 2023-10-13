using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface ITrainingClassAssignmentService
    {
        Task<IEnumerable<ClassroomAssignment>> GetAllAssignmentsAsync();
        Task<ClassroomAssignment?> GetAssignmentByIdAsync(int id);
        Task<bool> AddAssignmentAsync(ClassroomAssignment assignment);
        Task<bool> UpdateAssignmentAsync(ClassroomAssignment assignment);
        Task<bool> DeleteAssignmentAsync(int id);
    }
}
