using Microsoft.EntityFrameworkCore;
using StaffSightAPI.Data;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StaffSightAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;

        public EmployeeService(DataContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int pageNumber, int pageSize, string sortBy, string sortOrder, string fields)
        {
            // Start with a queryable that includes potential joins (with employee_dm, for example)
            var query = _context.EmployeePreHires.AsQueryable();

            // Join logic here if needed...

            // Sort
            if (sortOrder.ToLower() == "desc")
                query = query.OrderByDescending(e => EF.Property<object>(e, sortBy));
            else
                query = query.OrderBy(e => EF.Property<object>(e, sortBy));

            // Pagination
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            // Field Selection
            if (!string.IsNullOrWhiteSpace(fields))
            {
                var selectedFields = fields.Split(',').ToList();
                // Ensure the primary key is always included
                if (!selectedFields.Contains("EmpID"))
                {
                    selectedFields.Add("EmpID");
                }
                // Convert to dynamic objects with selected fields
                // This can be more complex and needs further implementation
                // For now, it will fetch all fields and then filter in memory
            }

            return await query.ToListAsync();
        }
        private readonly IGenericRepository<EmployeePreHire> _employeeRepository;

        public EmployeeService(IGenericRepository<EmployeePreHire> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeePreHire>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<EmployeePreHire?> GetEmployeeByIdAsync(string empID)
        {
            return await _context.EmployeePreHires.FirstOrDefaultAsync(e => e.EmpID == empID);
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

        public async Task DeleteEmployeeAsync(string empID)
        {
            var employee = await _context.EmployeePreHires.FirstOrDefaultAsync(e => e.EmpID == empID);
            if (employee != null)
            {
                _context.EmployeePreHires.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

    }
}
