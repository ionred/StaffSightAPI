using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class TrainingClassAssignmentService : ITrainingClassAssignmentService
    {
        private readonly IGenericRepository<ClassroomAssignment> _assignmentRepository;

        public TrainingClassAssignmentService(IGenericRepository<ClassroomAssignment> assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<IEnumerable<ClassroomAssignment>> GetAllAssignmentsAsync()
        {
            return await _assignmentRepository.GetAllAsync();
        }

        public async Task<ClassroomAssignment?> GetAssignmentByIdAsync(int id)
        {
            return await _assignmentRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddAssignmentAsync(ClassroomAssignment assignment)
        {
            await _assignmentRepository.AddAsync(assignment);
            return await _assignmentRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateAssignmentAsync(ClassroomAssignment assignment)
        {
            _assignmentRepository.Update(assignment);
            return await _assignmentRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            var assignment = await _assignmentRepository.GetByIdAsync(id);
            if (assignment == null) return false;

            _assignmentRepository.Delete(assignment);
            return await _assignmentRepository.SaveAllAsync();
        }
    }
}
