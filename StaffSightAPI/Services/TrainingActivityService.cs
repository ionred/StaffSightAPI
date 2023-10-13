using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class TrainingActivityService : ITrainingActivityService
    {
        private readonly IGenericRepository<TrainingActivity> _trainingActivityRepository;

        public TrainingActivityService(IGenericRepository<TrainingActivity> trainingActivityRepository)
        {
            _trainingActivityRepository = trainingActivityRepository;
        }

        public async Task<IEnumerable<TrainingActivity>> GetAllTrainingActivitiesAsync()
        {
            return await _trainingActivityRepository.GetAllAsync();
        }

        public async Task<TrainingActivity?> GetTrainingActivityByIdAsync(int trainingActivityId)
        {
            return await _trainingActivityRepository.GetByIdAsync(trainingActivityId);
        }

        public async Task<bool> AddTrainingActivityAsync(TrainingActivity trainingActivity)
        {
            await _trainingActivityRepository.AddAsync(trainingActivity);
            return await _trainingActivityRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateTrainingActivityAsync(TrainingActivity trainingActivity)
        {
            _trainingActivityRepository.Update(trainingActivity);
            return await _trainingActivityRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteTrainingActivityAsync(int trainingActivityId)
        {
            var trainingActivity = await _trainingActivityRepository.GetByIdAsync(trainingActivityId);
            if (trainingActivity == null) return false;

            _trainingActivityRepository.Delete(trainingActivity);
            return await _trainingActivityRepository.SaveAllAsync();
        }
    }
}
