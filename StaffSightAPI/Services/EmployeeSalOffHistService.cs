using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class EmployeeSalOffHistService : IEmployeeSalOffHistService
    {
        private readonly IGenericRepository<EmployeeSalOffHist> _salaryRepository;

        public EmployeeSalOffHistService(IGenericRepository<EmployeeSalOffHist> salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public async Task<IEnumerable<EmployeeSalOffHist>> GetAllSalariesAsync()
        {
            return await _salaryRepository.GetAllAsync();
        }

        public async Task<EmployeeSalOffHist?> GetSalaryByIdAsync(int id)
        {
            return await _salaryRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddSalaryAsync(EmployeeSalOffHist salary)
        {
            await _salaryRepository.AddAsync(salary);
            return await _salaryRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateSalaryAsync(EmployeeSalOffHist salary)
        {
            _salaryRepository.Update(salary);
            return await _salaryRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteSalaryAsync(int id)
        {
            var salary = await _salaryRepository.GetByIdAsync(id);
            if (salary == null) return false;

            _salaryRepository.Delete(salary);
            return await _salaryRepository.SaveAllAsync();
        }
    }
}
