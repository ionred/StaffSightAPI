using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSightAPI.Models;

namespace StaffSightAPI.Services
{
    public interface IClassNameBuilderService
    {
        Task<IEnumerable<ClassNameBuilder>> GetAllClassNameBuildersAsync();
        Task<ClassNameBuilder?> GetClassNameBuilderByIdAsync(int classNameBuilderId);
        Task<bool> AddClassNameBuilderAsync(ClassNameBuilder classNameBuilder);
        Task<bool> UpdateClassNameBuilderAsync(ClassNameBuilder classNameBuilder);
        Task<bool> DeleteClassNameBuilderAsync(int classNameBuilderId);
    }
}
