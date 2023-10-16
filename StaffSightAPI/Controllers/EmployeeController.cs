using System.Collections.Generic;
using System.Drawing.Printing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaffSightAPI.Models;
using StaffSightAPI.Services;


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


        [HttpGet("GetMergedEmployees")]
        public async Task<IActionResult> GetMergedEmployees([FromQuery] int pageSize = 15, [FromQuery] int pageNumber = 1, [FromQuery] string sortBy = "EmpId", [FromQuery] List<string> fields = null)
        {
            var employees = await _employeeService.GetMergedEmployees(pageSize, pageNumber, sortBy, fields ?? new List<string>());
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }
    }
}