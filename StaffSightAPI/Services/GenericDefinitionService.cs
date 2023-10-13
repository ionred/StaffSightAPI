using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class GenericDefinitionService : IGenericDefinitionService
    {
        private readonly IGenericRepository<GenericDefinition> _definitionRepository;

        public GenericDefinitionService(IGenericRepository<GenericDefinition> definitionRepository)
        {
            _definitionRepository = definitionRepository;
        }

        public async Task<IEnumerable<GenericDefinition>> GetAllDefinitionsAsync()
        {
            return await _definitionRepository.GetAllAsync();
        }

        public async Task<GenericDefinition?> GetDefinitionByIdAsync(int id)
        {
            return await _definitionRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddDefinitionAsync(GenericDefinition definition)
        {
            await _definitionRepository.AddAsync(definition);
            return await _definitionRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateDefinitionAsync(GenericDefinition definition)
        {
            _definitionRepository.Update(definition);
            return await _definitionRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteDefinitionAsync(int id)
        {
            var definition = await _definitionRepository.GetByIdAsync(id);
            if (definition == null) return false;

            _definitionRepository.Delete(definition);
            return await _definitionRepository.SaveAllAsync();
        }
    }
}
