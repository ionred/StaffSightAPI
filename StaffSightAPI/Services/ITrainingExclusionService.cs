using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface ITrainingExclusionService
    {
        Task<IEnumerable<TrainingExclusion>> GetAllTrainingExclusionsAsync();
        Task<TrainingExclusion?> GetTrainingExclusionByIdAsync(int trainingExclusionId);
        Task<bool> AddTrainingExclusionAsync(TrainingExclusion trainingExclusion);
        Task<bool> UpdateTrainingExclusionAsync(TrainingExclusion trainingExclusion);
        Task<bool> DeleteTrainingExclusionAsync(int trainingExclusionId);
    }
}
