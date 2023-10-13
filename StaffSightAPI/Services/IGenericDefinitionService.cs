using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IGenericDefinitionService
    {
        Task<IEnumerable<GenericDefinition>> GetAllDefinitionsAsync();
        Task<GenericDefinition?> GetDefinitionByIdAsync(int id);
        Task<bool> AddDefinitionAsync(GenericDefinition definition);
        Task<bool> UpdateDefinitionAsync(GenericDefinition definition);
        Task<bool> DeleteDefinitionAsync(int id);
    }
}
