using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class BilletManagementService : IBilletManagementService
    {
        private readonly IPreHireBilletRepository _billetRepository;

        public BilletManagementService(IPreHireBilletRepository billetRepository)
        {
            _billetRepository = billetRepository;
        }

        public async Task<IEnumerable<PreHireBillet>> GetAllBilletsAsync()
        {
            return await _billetRepository.GetAllAsync();
        }
        public async Task<PreHireBillet?> GetBilletByIdAsync(string billetNumber)
        {
            return await _billetRepository.GetByBilletNumberAsync(billetNumber);
        }

        //public async Task<PreHireBillet?> GetBilletByNumberAsync(string billetNumber)
        //{
        //    return await _billetRepository.GetByBilletNumberAsync(billetNumber);
        //}

        public async Task<bool> AddBilletAsync(PreHireBillet billet)
        {
            await _billetRepository.AddAsync(billet);
            return await _billetRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateBilletAsync(PreHireBillet billet)
        {
            _billetRepository.Update(billet);
            return await _billetRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteBilletAsync(string billetNumber)
        {
            var billet = await _billetRepository.GetByBilletNumberAsync(billetNumber);
            if (billet == null) return false;

            _billetRepository.Delete(billet);
            return await _billetRepository.SaveAllAsync();
        }


    }
}
