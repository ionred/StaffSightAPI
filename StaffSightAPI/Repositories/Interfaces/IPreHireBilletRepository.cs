using StaffSightAPI.Models;

namespace StaffSightAPI.Repositories.Interfaces
{
    public interface IPreHireBilletRepository : IGenericRepository<PreHireBillet>
    {
        Task<PreHireBillet?> GetByBilletNumberAsync(string billetNumber);
    }
}
