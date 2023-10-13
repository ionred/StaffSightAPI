using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface ITrainerAssignmentService
    {
        Task<IEnumerable<TrainerAssignment>> GetAllTrainerAssignmentsAsync();
        Task<TrainerAssignment?> GetTrainerAssignmentByIdAsync(int trainerAssignmentId);
        Task<bool> AddTrainerAssignmentAsync(TrainerAssignment trainerAssignment);
        Task<bool> UpdateTrainerAssignmentAsync(TrainerAssignment trainerAssignment);
        Task<bool> DeleteTrainerAssignmentAsync(int trainerAssignmentId);
    }
}
