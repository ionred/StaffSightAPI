using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class BranchService : IBranchService
    {
        private readonly IGenericRepository<Branch> _branchRepository;

        public BranchService(IGenericRepository<Branch> branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<IEnumerable<Branch>> GetAllBranchesAsync()
        {
            return await _branchRepository.GetAllAsync();
        }

        public async Task<Branch?> GetBranchByIdAsync(string branchId)
        {
            return await _branchRepository.GetByIdAsync(int.Parse(branchId));  // Assuming conversion is safe.
        }

        public async Task<bool> AddBranchAsync(Branch branch)
        {
            await _branchRepository.AddAsync(branch);
            return await _branchRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateBranchAsync(Branch branch)
        {
            _branchRepository.Update(branch);
            return await _branchRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteBranchAsync(string branchId)
        {
            var branch = await _branchRepository.GetByIdAsync(int.Parse(branchId));  // Assuming conversion is safe.
            if (branch == null) return false;
            
            _branchRepository.Delete(branch);
            return await _branchRepository.SaveAllAsync();
        }
    }
}
