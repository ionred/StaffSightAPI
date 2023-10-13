using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class TrainingExclusionService : ITrainingExclusionService
    {
        private readonly IGenericRepository<TrainingExclusion> _trainingExclusionRepository;

        public TrainingExclusionService(IGenericRepository<TrainingExclusion> trainingExclusionRepository)
        {
            _trainingExclusionRepository = trainingExclusionRepository;
        }

        public async Task<IEnumerable<TrainingExclusion>> GetAllTrainingExclusionsAsync()
        {
            return await _trainingExclusionRepository.GetAllAsync();
        }

        public async Task<TrainingExclusion?> GetTrainingExclusionByIdAsync(int trainingExclusionId)
        {
            return await _trainingExclusionRepository.GetByIdAsync(trainingExclusionId);
        }

        public async Task<bool> AddTrainingExclusionAsync(TrainingExclusion trainingExclusion)
        {
            await _trainingExclusionRepository.AddAsync(trainingExclusion);
            return await _trainingExclusionRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateTrainingExclusionAsync(TrainingExclusion trainingExclusion)
        {
            _trainingExclusionRepository.Update(trainingExclusion);
            return await _trainingExclusionRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteTrainingExclusionAsync(int trainingExclusionId)
        {
            var trainingExclusion = await _trainingExclusionRepository.GetByIdAsync(trainingExclusionId);
            if (trainingExclusion == null) return false;
            
            _trainingExclusionRepository.Delete(trainingExclusion);
            return await _trainingExclusionRepository.SaveAllAsync();
        }
    }
}
