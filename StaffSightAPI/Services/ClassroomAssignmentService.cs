using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class ClassroomAssignmentService : IClassroomAssignmentService
    {
        private readonly IGenericRepository<ClassroomAssignment> _classroomAssignmentRepository;

        public ClassroomAssignmentService(IGenericRepository<ClassroomAssignment> classroomAssignmentRepository)
        {
            _classroomAssignmentRepository = classroomAssignmentRepository;
        }

        public async Task<IEnumerable<ClassroomAssignment>> GetAllClassroomAssignmentsAsync()
        {
            return await _classroomAssignmentRepository.GetAllAsync();
        }

        public async Task<ClassroomAssignment?> GetClassroomAssignmentByIdAsync(int classroomAssignmentId)
        {
            return await _classroomAssignmentRepository.GetByIdAsync(classroomAssignmentId);
        }

        public async Task<bool> AddClassroomAssignmentAsync(ClassroomAssignment classroomAssignment)
        {
            await _classroomAssignmentRepository.AddAsync(classroomAssignment);
            return await _classroomAssignmentRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateClassroomAssignmentAsync(ClassroomAssignment classroomAssignment)
        {
            _classroomAssignmentRepository.Update(classroomAssignment);
            return await _classroomAssignmentRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteClassroomAssignmentAsync(int classroomAssignmentId)
        {
            var classroomAssignment = await _classroomAssignmentRepository.GetByIdAsync(classroomAssignmentId);
            if (classroomAssignment == null) return false;
            
            _classroomAssignmentRepository.Delete(classroomAssignment);
            return await _classroomAssignmentRepository.SaveAllAsync();
        }
    }
}
