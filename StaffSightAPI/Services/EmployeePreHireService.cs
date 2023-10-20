using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffSightAPI.Data;
using StaffSightAPI.DTOs;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace StaffSightAPI.Services
{
    public class EmployeePreHireService : IEmployeePreHireService
    {
        private readonly IGenericRepository<EmployeePreHire> _repository;
        private readonly DataContext _context;

        public EmployeePreHireService(IGenericRepository<EmployeePreHire> repository, DataContext context)
        {
            _repository = repository;
            _context = context;
        }
        public async Task<EmployeePreHire> GetEmployeePreHireById(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null)
            {
                return null;
            }
            return employee;
        }
        public async Task<EmployeePreHire> CreateEmployeePreHire(EmployeePreHireUpdateDto dto)
        {
            var newEmployee = new EmployeePreHire
            {
                EmpID = dto.EmpID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Location = dto.Location,
                AddressOne = dto.AddressOne,
                AddressTwo = dto.AddressTwo,
                City = dto.City,
                State = dto.State,
                Zip = dto.Zip,
                PhoneNumber = dto.PhoneNumber,
                PhoneExtension = dto.PhoneExtension,
                PhoneType = dto.PhoneType,
                PersonalEmail = dto.PersonalEmail,
                HireDate = dto.HireDate,
                BranchID = dto.BranchID,
                BilletNumber = dto.BilletNumber,
                SupervisorEmpID = dto.SupervisorEmpID,
                StfAsstEmpID = dto.StfAsstEmpID,
                ShiftID = dto.ShiftID,
                Vendor = dto.Vendor,
                ReqID = dto.ReqID,
                CostCenter = dto.CostCenter,
                Isp = dto.Isp,
                IspOther = dto.IspOther,
                Ethernet = dto.Ethernet,
                Ritm = dto.Ritm,
                ActivationID = dto.ActivationID,
                CiscoNumber = dto.CiscoNumber,
                IsContractor = dto.IsContractor,
                IsConversion = dto.IsConversion
            };
            await _repository.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return newEmployee;
        }

    public async Task UpdateEmployeePreHire(int id, JsonElement jsonBody)
        {
            var existingEmployee = await _repository.GetByIdAsync(id);
            if (existingEmployee == null)
            {
                throw new ArgumentException("Employee not found.");
            }

            // Deserialize the JSON to your DTO
            var dto = Newtonsoft.Json.JsonConvert.DeserializeObject<EmployeePreHireUpdateDto>(jsonBody.GetRawText());

            // Reflect on DTO properties
            var properties = typeof(EmployeePreHireUpdateDto).GetProperties();
            var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonBody.GetRawText());
            foreach (var item in jsonObject) 
            {
                
                var property = properties.FirstOrDefault(p => p.Name.Equals(item.Key, StringComparison.OrdinalIgnoreCase));
                if (property != null)
                {
                    // jsonItem.Key is in properties
                    // You can now work with the matched property and the jsonItem.Value as needed
                    var value = property.GetValue(dto);
                    var entityProperty = typeof(EmployeePreHire).GetProperty(property.Name);
                    entityProperty?.SetValue(existingEmployee, value);
                }
            }
                
            _repository.Update(existingEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task ReplaceEmployeePreHire(int id, EmployeePreHireUpdateDto dto)
        {
            var existingEmployee = await _repository.GetByIdAsync(id);
            if (existingEmployee == null)
            {
                throw new ArgumentException("Employee not found.");
            }
            var properties = typeof(EmployeePreHireUpdateDto).GetProperties();

            foreach (var property in properties)
            {
                // Check if the property has a value in the DTO
                var value = property.GetValue(dto);
                bool isRequiredField = (new[] { "EmpID", "FirstName", "LastName" }).Any(val => string.Equals(val, property.Name, StringComparison.OrdinalIgnoreCase));

                if (isRequiredField && value == null)
                { 
                    throw new ArgumentException($"Missing a required field: {property.Name}");
                }
                // Set the value to the corresponding property in the entity
                var entityProperty = typeof(EmployeePreHire).GetProperty(property.Name);
                entityProperty?.SetValue(existingEmployee, value);

            }
            _repository.Update(existingEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeePreHire(int id)
        {
            var existingEmployee = await _repository.GetByIdAsync(id);
            if (existingEmployee == null)
            {
                throw new ArgumentException("Employee not found.");
            }
            // replace with set isDelete = 1
            //   _repository.Delete(existingEmployee);
            await _context.SaveChangesAsync();
        }
    }


}
