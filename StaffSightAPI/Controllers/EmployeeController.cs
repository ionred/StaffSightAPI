using Microsoft.AspNetCore.Mvc;
using StaffSightAPI.Models;
using StaffSightAPI.Services;
using System;
using System.Threading.Tasks;


namespace StaffSightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // We'll add the endpoint next
        [HttpGet]
        public async Task<IActionResult> GetEmployees([FromQuery] int pageNumber = 1,
                                              [FromQuery] int pageSize = 15,
                                              [FromQuery] string sortBy = "empID",
                                              [FromQuery] string sortOrder = "asc",
                                              [FromQuery] string fields = "")
        {

            try
            {
                // Use the service to retrieve employees
                var result = await _employeeService.GetEmployeesAsync(pageNumber, pageSize, sortBy, sortOrder, fields);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            {
                // Handle the exception (log it, etc.)
                return StatusCode(500, "Internal server error");
            }
#pragma warning restore CS0168 // Variable is declared but never used
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(string id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            {
                // Handle the exception (log it, etc.)
                return StatusCode(500, "Internal server error");
            }
#pragma warning restore CS0168 // Variable is declared but never used
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeePreHire employee)
        {
            try
            {
                await _employeeService.AddEmployeeAsync(employee);
                return StatusCode(201); // Created
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            {
                // Handle the exception (log it, etc.)
                return StatusCode(500, "Internal server error");
            }
#pragma warning restore CS0168 // Variable is declared but never used
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(string id, EmployeePreHire updatedEmployee)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);

                if (employee == null)
                {
                    return NotFound();
                }

                await _employeeService.UpdateEmployeeAsync(updatedEmployee);

                return NoContent(); // Successfully updated
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            {
                // Handle the exception (log it, etc.)
                return StatusCode(500, "Internal server error");
            }
#pragma warning restore CS0168 // Variable is declared but never used
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);

                if (employee == null)
                {
                    return NotFound();
                }

                await _employeeService.DeleteEmployeeAsync(id);

                return NoContent(); // Successfully deleted
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            {
                // Handle the exception (log it, etc.)
                return StatusCode(500, "Internal server error");
            }
#pragma warning restore CS0168 // Variable is declared but never used
        }





    }
}