using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Interfaces;

namespace StaffSightAPI.Services
{
    public class ClassNameBuilderService : IClassNameBuilderService
    {
        private readonly IGenericRepository<ClassNameBuilder> _classNameBuilderRepository;

        public ClassNameBuilderService(IGenericRepository<ClassNameBuilder> classNameBuilderRepository)
        {
            _classNameBuilderRepository = classNameBuilderRepository;
        }

        public async Task<IEnumerable<ClassNameBuilder>> GetAllClassNameBuildersAsync()
        {
            return await _classNameBuilderRepository.GetAllAsync();
        }

        public async Task<ClassNameBuilder?> GetClassNameBuilderByIdAsync(int classNameBuilderId)
        {
            return await _classNameBuilderRepository.GetByIdAsync(classNameBuilderId);
        }

        public async Task<bool> AddClassNameBuilderAsync(ClassNameBuilder classNameBuilder)
        {
            await _classNameBuilderRepository.AddAsync(classNameBuilder);
            return await _classNameBuilderRepository.SaveAllAsync();
        }

        public async Task<bool> UpdateClassNameBuilderAsync(ClassNameBuilder classNameBuilder)
        {
            _classNameBuilderRepository.Update(classNameBuilder);
            return await _classNameBuilderRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteClassNameBuilderAsync(int classNameBuilderId)
        {
            var classNameBuilder = await _classNameBuilderRepository.GetByIdAsync(classNameBuilderId);
            if (classNameBuilder == null) return false;
            
            _classNameBuilderRepository.Delete(classNameBuilder);
            return await _classNameBuilderRepository.SaveAllAsync();
        }
    }
}
