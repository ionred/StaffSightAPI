using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffSightAPI.Data;
using StaffSightAPI.Models;

namespace StaffSightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePreHireController : ControllerBase
    {
        private readonly StaffSightContext _context;

        public EmployeePreHireController(StaffSightContext context)
        {
            _context = context;
        }

        // GET: api/EmployeePreHire
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeePreHire>>> GetEmployeePreHires(int pageNumber = 1, int pageSize = 10, string sortColumn = "EmpID", bool sortDesc = false)
        {
          if (_context.EmployeePreHires == null)
          {
              return NotFound();
          }
            var employees = _context.EmployeePreHires.AsQueryable();  // Make sure you're working with IQueryable
            if(sortDesc)
            {
                employees = employees.OrderByDescending(e => EF.Property<object>(e, sortColumn));
            }
            else
            {
                employees = employees.OrderBy(e => EF.Property<object>(e, sortColumn));
            }
            var pagedEmployees = await employees.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            
            return Ok(pagedEmployees);
            //return await _context.EmployeePreHires.ToListAsync();
        }

        // GET: api/EmployeePreHire/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeePreHire>> GetEmployeePreHire(string id)
        {
          if (_context.EmployeePreHires == null)
          {
              return NotFound();
          }
            var employeePreHire = await _context.EmployeePreHires.FindAsync(id);

            if (employeePreHire == null)
            {
                return NotFound();
            }

            return employeePreHire;
        }

        // PUT: api/EmployeePreHire/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeePreHire(string id, EmployeePreHire employeePreHire)
        {
            if (id != employeePreHire.EmpID)
            {
                return BadRequest();
            }

            _context.Entry(employeePreHire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeePreHireExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeePreHire
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeePreHire>> PostEmployeePreHire(EmployeePreHire employeePreHire)
        {
          if (_context.EmployeePreHires == null)
          {
              return Problem("Entity set 'StaffSightContext.EmployeePreHires'  is null.");
          }
            _context.EmployeePreHires.Add(employeePreHire);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeePreHireExists(employeePreHire.EmpID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeePreHire", new { id = employeePreHire.EmpID }, employeePreHire);
        }

        // DELETE: api/EmployeePreHire/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeePreHire(string id)
        {
            if (_context.EmployeePreHires == null)
            {
                return NotFound();
            }
            var employeePreHire = await _context.EmployeePreHires.FindAsync(id);
            if (employeePreHire == null)
            {
                return NotFound();
            }

            _context.EmployeePreHires.Remove(employeePreHire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeePreHireExists(string id)
        {
            return (_context.EmployeePreHires?.Any(e => e.EmpID == id)).GetValueOrDefault();
        }
    }
}
