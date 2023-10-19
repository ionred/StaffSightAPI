using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IEmployeeNoteService
    {
        Task<IEnumerable<EmployeeNote>> GetAllNotesAsync();
        Task<EmployeeNote?> GetNoteByIdAsync(int id);
        Task<bool> AddNoteAsync(EmployeeNote note);
        Task<bool> UpdateNoteAsync(EmployeeNote note);
        Task<bool> DeleteNoteAsync(int id);
        Task<List<EmployeeNote>> GetEmployeeNotes(int? preHireID);
    }
}
