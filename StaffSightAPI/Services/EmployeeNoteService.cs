using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class EmployeeNoteService : IEmployeeNoteService
    {
        private readonly IGenericRepository<EmployeeNote> _noteRepository;

        public EmployeeNoteService(IGenericRepository<EmployeeNote> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<EmployeeNote>> GetAllNotesAsync()
        {
            return await _noteRepository.GetAllAsync();
        }

        public async Task<EmployeeNote?> GetNoteByIdAsync(int id)
        {
            return await _noteRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddNoteAsync(EmployeeNote note)
        {
            await _noteRepository.AddAsync(note);
            return await _noteRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateNoteAsync(EmployeeNote note)
        {
            _noteRepository.Update(note);
            return await _noteRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            if (note == null) return false;

            _noteRepository.Delete(note);
            return await _noteRepository.SaveAllAsync();
        }

        public async Task<List<EmployeeNote>> GetEmployeeNotes(int? preHireID)
        {
            return await _noteRepository.GetByPreHireIdAsync(preHireID);
        }
    }
}
