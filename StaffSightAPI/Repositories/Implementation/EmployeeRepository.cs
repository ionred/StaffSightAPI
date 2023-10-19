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
                             Location = e.Location,
                             HireDate = e.HireDate,
                             BilletNumber = e.BilletNumber,
                             Vendor = e.Vendor,
                             SupervisorEmpID = e.SupervisorEmpID,
                             BranchID = e.BranchID,
                             AddressOne = e.AddressOne,
                             AddressTwo = e.AddressTwo,
                             City = e.City,
                             State = e.State,
                             Zip = e.Zip,
                             PhoneNumber = e.PhoneNumber,
                             PhoneExtension = e.PhoneExtension,
                             PhoneType = e.PhoneType,
                             PersonalEmail = e.PersonalEmail,
                             ShiftID = e.ShiftID,
                             ReqID = e.ReqID,
                             CostCenter = e.CostCenter,
                             StfAsstEmpID = e.StfAsstEmpID,
                             Isp = e.Isp,
                             IspOther = e.IspOther,
                             Ethernet = e.Ethernet,
                             Ritm = e.Ritm,
                             ActivationID = e.ActivationID,
                             CiscoNumber = e.CiscoNumber,
                             IsContractor = e.IsContractor,
                             IsConversion = e.IsConversion,
                             HrEmpID = subDm == null ? null : subDm.HrEmpID,
                             HrFirstName = subDm == null ? null : subDm.HrFirstName,
                             HrLastName = subDm == null ? null : subDm.HrLastName,
                             HrLocation = subDm == null ? null : subDm.HrLocation,
                             HrHireDate = subDm == null ? null : subDm.HrHireDate,
                             HrBilletNumber = subDm == null ? null : subDm.HrBilletNumber,
                             HrVendor = subDm == null ? null : subDm.HrVendor,
                             HrSupervisorEmpID = subDm == null ? null : subDm.HrSupervisorEmpID,
                             HrBranchID = subDm == null ? null : subDm.HrBranchID,
                             HrIsContractor = subDm == null ? null : subDm.HrIsContractor
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

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IEnumerable<EmployeePreHire>> GetAllAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Implement this method
            throw new NotImplementedException();
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<EmployeePreHire> GetByIdAsync(int id)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Implement this method
            throw new NotImplementedException();
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task AddAsync(EmployeePreHire entity)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
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

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<bool> SaveAllAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
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
        public async Task<EmployeeDto> GetMergedEmployeeById(int? preHireID, string? empID)
        {
            // First, try to fetch using preHireID if it's provided
            if (preHireID.HasValue)
            {
                var resultByPreHireID = await GetEmployee(e => e.PreHireID == preHireID);
                if (resultByPreHireID != null)
                {
                    return resultByPreHireID;
                }
            }

            // If result is not found by preHireID or it's not provided, try using empID
            if (!string.IsNullOrEmpty(empID))
            {
                return await GetEmployee(e => e.EmpID == empID);
            }

            return null;
        }
        private async Task<EmployeeDto?> GetEmployee(Func<EmployeePreHire, bool> predicate)
        {
            var result = (from e in _context.EmployeePreHires.Where(predicate)
                          join d in _context.EmployeeDMs on e.EmpID equals d.HrEmpID into gj
                          from subDm in gj.DefaultIfEmpty()
                          select new EmployeeDto
                          {
                              PreHireID = e.PreHireID,
                              EmpID = e.EmpID.ToUpper(),
                              FirstName = e.FirstName,
                              LastName = e.LastName,
                              Location = e.Location,
                              HireDate = e.HireDate,
                              BilletNumber = e.BilletNumber,
                              Vendor = e.Vendor,
                              SupervisorEmpID = e.SupervisorEmpID,
                              BranchID = e.BranchID,
                              AddressOne = e.AddressOne,
                              AddressTwo = e.AddressTwo,
                              City = e.City,
                              State = e.State,
                              Zip = e.Zip,
                              PhoneNumber = e.PhoneNumber,
                              PhoneExtension = e.PhoneExtension,
                              PhoneType = e.PhoneType,
                              PersonalEmail = e.PersonalEmail,
                              ShiftID = e.ShiftID,
                              ReqID = e.ReqID,
                              CostCenter = e.CostCenter,
                              StfAsstEmpID = e.StfAsstEmpID,
                              Isp = e.Isp,
                              IspOther = e.IspOther,
                              Ethernet = e.Ethernet,
                              Ritm = e.Ritm,
                              ActivationID = e.ActivationID,
                              CiscoNumber = e.CiscoNumber,
                              IsContractor = e.IsContractor,
                              IsConversion = e.IsConversion,
                              HrEmpID = subDm == null ? null : subDm.HrEmpID,
                              HrFirstName = subDm == null ? null : subDm.HrFirstName,
                              HrLastName = subDm == null ? null : subDm.HrLastName,
                              HrLocation = subDm == null ? null : subDm.HrLocation,
                              HrHireDate = subDm == null ? null : subDm.HrHireDate,
                              HrBilletNumber = subDm == null ? null : subDm.HrBilletNumber,
                              HrVendor = subDm == null ? null : subDm.HrVendor,
                              HrSupervisorEmpID = subDm == null ? null : subDm.HrSupervisorEmpID,
                              HrBranchID = subDm == null ? null : subDm.HrBranchID,
                              HrIsContractor = subDm == null ? null : subDm.HrIsContractor
                          }).FirstOrDefault();

            return result;
        }

        public Task<List<EmployeePreHire>> GetByPreHireIdAsync(int? preHireID)
        {
            throw new NotImplementedException();
        }
    }

}