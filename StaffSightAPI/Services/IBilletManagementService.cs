using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IBilletManagementService
    {
        Task<IEnumerable<PreHireBillet>> GetAllBilletsAsync();
        Task<PreHireBillet?> GetBilletByIdAsync(string billetNumber);
        Task<bool> AddBilletAsync(PreHireBillet billet);
        Task<bool> UpdateBilletAsync(PreHireBillet billet);
        Task<bool> DeleteBilletAsync(string billetNumber);
    }
}
