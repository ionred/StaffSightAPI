using Microsoft.EntityFrameworkCore;
using StaffSightAPI.Data;
using StaffSightAPI.DTOs;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
namespace StaffSightAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //public async Task<IEnumerable<EmployeePreHire>> GetAllEmployeesAsync()
        //{
        //    return await _employeeRepository.GetAllAsync();
        //}

        //public async Task<EmployeePreHire> GetEmployeeByIdAsync(int id)
        //{
        //    return await _employeeRepository.GetByIdAsync(id);
        //}

        //public async Task AddEmployeeAsync(EmployeePreHire employee)
        //{
        //    await _employeeRepository.AddAsync(employee);
        //    await _employeeRepository.SaveAllAsync();
        //}

        //public async Task UpdateEmployeeAsync(EmployeePreHire employee)
        //{
        //    _employeeRepository.Update(employee);
        //    await _employeeRepository.SaveAllAsync();
        //}

        //public async Task DeleteEmployeeAsync(int id)
        //{
        //    var employee = await _employeeRepository.GetByIdAsync(id);
        //    _employeeRepository.Delete(employee);
        //    await _employeeRepository.SaveAllAsync();
        //}

        public async Task<List<object>> GetMergedEmployees(int pageSize, int pageNumber, string sortBy, List<string> fields)
        {
            return await _employeeRepository.GetMergedEmployees(pageSize, pageNumber, sortBy, fields);
        }

        public async Task<EmployeeDto> GetMergedEmployeeById(int? preHireID, string? empID)
        {
            return await _employeeRepository.GetMergedEmployeeById(preHireID, empID);
        }

    }
}
