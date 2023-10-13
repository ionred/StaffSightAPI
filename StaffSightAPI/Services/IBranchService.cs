using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IBranchService
    {
        Task<IEnumerable<Branch>> GetAllBranchesAsync();
        Task<Branch?> GetBranchByIdAsync(string branchId);
        Task<bool> AddBranchAsync(Branch branch);
        Task<bool> UpdateBranchAsync(Branch branch);
        Task<bool> DeleteBranchAsync(string branchId);
    }
}
