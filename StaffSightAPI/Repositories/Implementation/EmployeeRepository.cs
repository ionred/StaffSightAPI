using StaffSightAPI.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffSightAPI.Repositories.Implementations;
using StaffSightAPI.Models;
using StaffSightAPI.DTOs;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Data.Repositories.Implementations
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesWithDmAsync(int pageNumber, int pageSize, string sortBy, string sortOrder, string fields)
        {
            // Implement the LEFT JOIN logic here...
            var query = from preHire in _context.EmployeePreHire
                        join dm in _context.EmployeeDm on preHire.EmpID equals dm.EmpID into gj
                        from subDm in gj.DefaultIfEmpty()
                        select new EmployeeDto
                        {
                            EmpID = preHire.EmpID,
                            FirstName = preHire.FirstName,
                            LastName = preHire.LastName,
                            ActivationID = preHire.ActivationID,
                            AddressOne = preHire.AddressOne,
                            AddressTwo = preHire.AddressTwo,

                            // ... other fields from preHire ...
                            DmFirstName = subDm.FirstName,
                            DmLastName = subDm.LastName
                            // ... other fields from dm ...
                        };

            // ... rest of the logic (sorting, paging, etc.)
            return await query.ToListAsync();
        }
    }
}
