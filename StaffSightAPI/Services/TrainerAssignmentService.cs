using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class TrainerAssignmentService : ITrainerAssignmentService
    {
        private readonly IGenericRepository<TrainerAssignment> _trainerAssignmentRepository;

        public TrainerAssignmentService(IGenericRepository<TrainerAssignment> trainerAssignmentRepository)
        {
            _trainerAssignmentRepository = trainerAssignmentRepository;
        }

        public async Task<IEnumerable<TrainerAssignment>> GetAllTrainerAssignmentsAsync()
        {
            return await _trainerAssignmentRepository.GetAllAsync();
        }

        public async Task<TrainerAssignment?> GetTrainerAssignmentByIdAsync(int trainerAssignmentId)
        {
            return await _trainerAssignmentRepository.GetByIdAsync(trainerAssignmentId);
        }

        public async Task<bool> AddTrainerAssignmentAsync(TrainerAssignment trainerAssignment)
        {
            await _trainerAssignmentRepository.AddAsync(trainerAssignment);
            return await _trainerAssignmentRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateTrainerAssignmentAsync(TrainerAssignment trainerAssignment)
        {
            _trainerAssignmentRepository.Update(trainerAssignment);
            return await _trainerAssignmentRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteTrainerAssignmentAsync(int trainerAssignmentId)
        {
            var trainerAssignment = await _trainerAssignmentRepository.GetByIdAsync(trainerAssignmentId);
            if (trainerAssignment == null) return false;

            _trainerAssignmentRepository.Delete(trainerAssignment);
            return await _trainerAssignmentRepository.SaveAllAsync();
        }
    }
}
