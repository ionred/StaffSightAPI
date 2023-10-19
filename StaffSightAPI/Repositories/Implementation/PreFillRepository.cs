using Microsoft.EntityFrameworkCore;
using StaffSightAPI.Data;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;
using System.Linq;

namespace StaffSightAPI.Repositories.Implementation
{
    public class PreFillRepository : IPreFillRepository
    {
        private readonly DataContext _context;

        public PreFillRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDM>> GetSupervisors()
        {
            return await _context.EmployeeDMs
                .Where(e => e.HrJobTitle.Contains("Supervisor") && e.HrBranchID == "W00001")
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetDistinctBilletNumbers()
        {
            return await _context.EmployeeDMs
                .Select(e => e.HrBilletNumber)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<Location>> GetDistinctLocations()
        {
            // Get locations with names from EmployeeDMs
            var locationsFromEmployeeDMs = _context.EmployeeDMs
                                                    .Where(e => e.HrLocationID.HasValue)
                                                    .Select(e => new Location { LocationID = e.HrLocationID.Value, LocationName = e.HrLocation })
                                                    .Distinct();

            // Get locations with names from Locations table
            var locationsFromLocationsTable = _context.Locations
                                                      .Select(l => new Location { LocationID = l.LocationID, LocationName = l.LocationName });

            return await locationsFromEmployeeDMs
                .Union(locationsFromLocationsTable)
                .Distinct()
                .ToListAsync();
        }


        public async Task<IEnumerable<GenericDefinition>> GetVendors()
        {
            return await _context.GenericDefinitions
                .Where(g => g.DefinitionType == "Vendor")
                .ToListAsync();
        }

        public async Task<IEnumerable<GenericDefinition>> GetISPs()
        {
            return await _context.GenericDefinitions
                .Where(g => g.DefinitionType == "ISP")
                .ToListAsync();
        }

        // ... implement other methods
    }

}
