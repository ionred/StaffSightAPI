using StaffSightAPI.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using StaffSightAPI.Repositories.Implementations;
using StaffSightAPI.Models;
using StaffSightAPI.DTOs;
using StaffSightAPI.Repositories.Interfaces;
using System.Globalization;
using System.Reflection;
using System.ComponentModel;
using System.Dynamic;

namespace StaffSightAPI.Repositories.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<object>> GetMergedEmployees(int pageSize, int pageNumber, string sortBy, List<string> fields)
        {
            var query = (from e in _context.EmployeePreHires
                         join d in _context.EmployeeDMs.Where(x => x.HrCurrentRow == 1) on e.EmpID equals d.HrEmpID into gj
                         from subDm in gj.DefaultIfEmpty()
                         select new EmployeeDto
                         {
                             PreHireID = e.PreHireID,
                             EmpID = e.EmpID.ToUpper(),
                             FirstName = e.FirstName,
                             LastName = e.LastName,
                             HrFirstName = subDm.HrFirstName,
                             HrLastName = subDm.HrLastName
                         }).AsQueryable();

            if (!string.IsNullOrEmpty(sortBy))
            {
                query = query.OrderBy(sortBy);
            }

            var pagedData = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (fields != null && fields.Any())
            {
                // Ensure primary keys are always included
                if (!fields.Contains("EmpId"))
                {
                    fields.Insert(0, "EmpId");
                }
                if (!fields.Contains("PreHireID"))
                {
                    fields.Insert(0, "PreHireID");
                }

                string selectString = string.Join(", ", fields);
                var selectedEmployees = await pagedData.Select($"new({selectString})").ToDynamicListAsync();

                return ConvertDynamicListToExpandoObjectList(selectedEmployees);
            }
            else
            {
                return (await pagedData.ToListAsync()).Cast<object>().ToList();
            }
        }

        public async Task<IEnumerable<EmployeePreHire>> GetAllAsync()
        {
            // Implement this method
            throw new NotImplementedException();
        }

        public async Task<EmployeePreHire> GetByIdAsync(int id)
        {
            // Implement this method
            throw new NotImplementedException();
        }

        public async Task AddAsync(EmployeePreHire entity)
        {
            // Implement this method
            throw new NotImplementedException();
        }

        public void Update(EmployeePreHire entity)
        {
            // Implement this method
            throw new NotImplementedException();
        }

        public void Delete(EmployeePreHire entity)
        {
            // Implement this method
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAllAsync()
        {
            // Implement this method
            throw new NotImplementedException();
        }

        private List<object> ConvertDynamicListToExpandoObjectList(IEnumerable<dynamic> dynamicList)
        {
            var expandoList = new List<object>();
            foreach (var item in dynamicList)
            {
                IDictionary<string, object> expando = new ExpandoObject();

                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(item))
                {
                    var obj = propertyDescriptor.GetValue(item);
                    expando.Add(propertyDescriptor.Name, obj);
                }

                expandoList.Add(expando);
            }

            return expandoList;
        }
    }
}