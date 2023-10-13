using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class LocationService : ILocationService
    {
        private readonly IGenericRepository<Location> _locationRepository;

        public LocationService(IGenericRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return await _locationRepository.GetAllAsync();
        }

        public async Task<Location?> GetLocationByIdAsync(int locationId)
        {
            return await _locationRepository.GetByIdAsync(locationId);
        }

        public async Task<bool> AddLocationAsync(Location location)
        {
            await _locationRepository.AddAsync(location);
            return await _locationRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateLocationAsync(Location location)
        {
            _locationRepository.Update(location);
            return await _locationRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteLocationAsync(int locationId)
        {
            var location = await _locationRepository.GetByIdAsync(locationId);
            if (location == null) return false;
            
            _locationRepository.Delete(location);
            return await _locationRepository.SaveAllAsync();
        }
    }
}
