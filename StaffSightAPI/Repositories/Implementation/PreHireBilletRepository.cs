using StaffSightAPI.Models;
using StaffSightAPI.Data;
using Microsoft.EntityFrameworkCore;
using StaffSightAPI.Repositories.Implementations;
using StaffSightAPI.Repositories.Interfaces;


namespace StaffSightAPI.Repositories.Implementations
{
    public class PreHireBilletRepository : GenericRepository<PreHireBillet>, IPreHireBilletRepository
    {
        private readonly DataContext _context;

        public PreHireBilletRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PreHireBillet?> GetByBilletNumberAsync(string billetNumber)
        {
            return await _context.PreHireBillets.FirstOrDefaultAsync(x => x.BilletNumber == billetNumber);

        }
    }
}
