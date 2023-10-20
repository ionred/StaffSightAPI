using Microsoft.AspNetCore.Mvc;
using StaffSightAPI.DTOs;
using StaffSightAPI.Models;
using StaffSightAPI.Services;
using System.Net;
using System.Text.Json;


namespace StaffSightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePreHireController : ControllerBase
    {
        private readonly IEmployeePreHireService _service;

        public EmployeePreHireController(IEmployeePreHireService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeePreHire>> GetEmployeePreHireById(int id)
        {
            try
            {
                var employee = await _service.GetEmployeePreHireById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                // Log the exception, etc.
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeePreHire(EmployeePreHireUpdateDto dto)
        {
            var newEmployee = await _service.CreateEmployeePreHire(dto);
            return CreatedAtAction(nameof(GetEmployeePreHireById), new { id = newEmployee.PreHireID }, newEmployee);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEmployeePreHire(int id, [FromBody] JsonElement jsonBody)
        {
            await _service.UpdateEmployeePreHire(id, jsonBody);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ReplaceEmployeePreHire(int id, EmployeePreHireUpdateDto dto)
        {
            try
            {
                await _service.ReplaceEmployeePreHire(id, dto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeePreHire(int id)
        {
            //await _service.DeleteEmployeePreHire(id);
            //return NoContent();
            StatusCodeResult scr = this.StatusCode(501);
            return scr;


        }
    }
}
