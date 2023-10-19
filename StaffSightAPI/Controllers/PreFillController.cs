using Microsoft.AspNetCore.Mvc;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;
using StaffSightAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class PreFillController : ControllerBase
{
    private readonly IPreFillService _preFillService;


    public PreFillController(IPreFillService preFillService)
    {
        _preFillService = preFillService;
    }

    [HttpGet("Supervisors")]
    public async Task<ActionResult<IEnumerable<EmployeeDM>>> GetSupervisors()
    {
        var supervisors = await _preFillService.GetSupervisors();
        return Ok(supervisors);
    }

    [HttpGet("BilletNumbers")]
    public async Task<ActionResult<IEnumerable<string>>> GetBilletNumbers()
    {
        var billetNumbers = await _preFillService.GetDistinctBilletNumbers();
        return Ok(billetNumbers);
    }

    [HttpGet("Locations")]
    public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
    {
        var locations = await _preFillService.GetDistinctLocations();
        return Ok(locations);
    }

    [HttpGet("Vendors")]
    public async Task<ActionResult<IEnumerable<GenericDefinition>>> GetVendors()
    {
        var vendors = await _preFillService.GetVendors();
        return Ok(vendors);
    }

    [HttpGet("ISPs")]
    public async Task<ActionResult<IEnumerable<GenericDefinition>>> GetISPs()
    {
        var isps = await _preFillService.GetISPs();
        return Ok(isps);
    }
}
