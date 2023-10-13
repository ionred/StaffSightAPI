using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class TrainingClassService : ITrainingClassService
    {
        private readonly IGenericRepository<TrainingClass> _trainingClassRepository;

        public TrainingClassService(IGenericRepository<TrainingClass> trainingClassRepository)
        {
            _trainingClassRepository = trainingClassRepository;
        }

        public async Task<IEnumerable<TrainingClass>> GetAllTrainingClassesAsync()
        {
            return await _trainingClassRepository.GetAllAsync();
        }

        public async Task<TrainingClass?> GetTrainingClassByIdAsync(int trainingClassId)
        {
            return await _trainingClassRepository.GetByIdAsync(trainingClassId);
        }

        public async Task<bool> AddTrainingClassAsync(TrainingClass trainingClass)
        {
            await _trainingClassRepository.AddAsync(trainingClass);
            return await _trainingClassRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateTrainingClassAsync(TrainingClass trainingClass)
        {
            _trainingClassRepository.Update(trainingClass);
            return await _trainingClassRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteTrainingClassAsync(int trainingClassId)
        {
            var trainingClass = await _trainingClassRepository.GetByIdAsync(trainingClassId);
            if (trainingClass == null) return false;

            _trainingClassRepository.Delete(trainingClass);
            return await _trainingClassRepository.SaveAllAsync();
        }
    }
}
