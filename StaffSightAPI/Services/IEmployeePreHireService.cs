using Microsoft.AspNetCore.Mvc;
using StaffSightAPI.DTOs;
using StaffSightAPI.Models;
using System.Text.Json;

namespace StaffSightAPI.Services
{
    public interface IEmployeePreHireService
    {
        Task<EmployeePreHire> GetEmployeePreHireById(int id);
        Task<EmployeePreHire> CreateEmployeePreHire(EmployeePreHireUpdateDto dto);
        Task UpdateEmployeePreHire(int id, JsonElement jsonBody);
        Task ReplaceEmployeePreHire(int id, EmployeePreHireUpdateDto dto);
        Task DeleteEmployeePreHire(int id);

        // ... any other methods like retrieving EmployeePreHire.
    }


}