using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllLocationsAsync();
        Task<Location?> GetLocationByIdAsync(int locationId);
        Task<bool> AddLocationAsync(Location location);
        Task<bool> UpdateLocationAsync(Location location);
        Task<bool> DeleteLocationAsync(int locationId);
    }
}
