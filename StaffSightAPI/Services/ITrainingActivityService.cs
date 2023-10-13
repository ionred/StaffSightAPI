using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface ITrainingActivityService
    {
        Task<IEnumerable<TrainingActivity>> GetAllTrainingActivitiesAsync();
        Task<TrainingActivity?> GetTrainingActivityByIdAsync(int trainingActivityId);
        Task<bool> AddTrainingActivityAsync(TrainingActivity trainingActivity);
        Task<bool> UpdateTrainingActivityAsync(TrainingActivity trainingActivity);
        Task<bool> DeleteTrainingActivityAsync(int trainingActivityId);
    }
}
