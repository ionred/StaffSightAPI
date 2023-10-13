using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<EmployeePreHire> _employeeRepository;

        public EmployeeService(IGenericRepository<EmployeePreHire> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeePreHire>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<EmployeePreHire?> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddEmployeeAsync(EmployeePreHire employee)
        {
            await _employeeRepository.AddAsync(employee);
            return await _employeeRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeePreHire employee)
        {
            _employeeRepository.Update(employee);
            return await _employeeRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) return false;

            _employeeRepository.Delete(employee);
            return await _employeeRepository.SaveAllAsync();
        }
    }
}
