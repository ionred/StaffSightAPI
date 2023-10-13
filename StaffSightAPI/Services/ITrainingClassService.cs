using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface ITrainingClassService
    {
        Task<IEnumerable<TrainingClass>> GetAllTrainingClassesAsync();
        Task<TrainingClass?> GetTrainingClassByIdAsync(int trainingClassId);
        Task<bool> AddTrainingClassAsync(TrainingClass trainingClass);
        Task<bool> UpdateTrainingClassAsync(TrainingClass trainingClass);
        Task<bool> DeleteTrainingClassAsync(int trainingClassId);
    }
}
