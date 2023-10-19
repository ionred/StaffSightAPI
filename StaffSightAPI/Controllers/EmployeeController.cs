using System.Collections.Generic;
using System.Drawing.Printing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaffSightAPI.DTOs;
using StaffSightAPI.Models;
using StaffSightAPI.Services;
using static Azure.Core.HttpHeader;


namespace StaffSightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeSalOffHistService _salaryService;
        private readonly IEmployeeNoteService _noteService;

        public EmployeeController(IEmployeeService employeeService, IEmployeeSalOffHistService salaryService,IEmployeeNoteService noteService)
        {
            _employeeService = employeeService;
            _salaryService = salaryService;
            _noteService = noteService;


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
        
        [HttpGet("GetEmployeeByIDs")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById([FromQuery] int? preHireID, [FromQuery] string? empID)
        {
            if (!preHireID.HasValue && string.IsNullOrEmpty(empID))
            {
                return BadRequest("Either PreHireID or EmpID must be provided.");
            }

            var employee = await _employeeService.GetMergedEmployeeById(preHireID, empID);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet("GetEmployeeDetails")]
        public async Task<ActionResult<EmployeeDetailAggregate>> GetEmployeeData([FromQuery] int? preHireID, [FromQuery] string? empID)
        {
            int? preHireIDToPass = preHireID;
            List<EmployeeSalOffHist> salaryInformation = new List<EmployeeSalOffHist>();  // Initialize with empty list
            List<EmployeeNote> notes = new List<EmployeeNote>();  // Make sure notes is also not null
            
            if (!preHireID.HasValue && string.IsNullOrEmpty(empID))
            {
                return BadRequest("Either preHireID or empID must be provided.");
            }

            var employee = await _employeeService.GetMergedEmployeeById(preHireIDToPass, empID);
            
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }
            
            if (preHireIDToPass == null)
            {
                preHireIDToPass = employee.PreHireID;
            }

            if (preHireIDToPass.HasValue) //&& User.IsInRole("NotesViewer")) //to be aadded
            {
                notes = await _noteService.GetEmployeeNotes(preHireIDToPass);
                //if (User.IsInRole("SalaryViewer")) //to be aadded
                //{ 
                    salaryInformation = await _salaryService.GetSalaryByPreHireIdAsync(preHireIDToPass);
                //}
            }

            var aggregateDto = new EmployeeDetailAggregate
            {
                Employee = employee,
                //TODO Handle Authorization!
                SalaryInformation = salaryInformation,  // Initialize with empty list
                Notes = notes  // Make sure notes is also not null
            };



            return Ok(aggregateDto);
        }

    }
}