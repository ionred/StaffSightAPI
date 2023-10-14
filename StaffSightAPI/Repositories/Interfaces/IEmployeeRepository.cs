using StaffSightAPI.Repositories.Interfaces;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<IEnumerable<EmployeeDto>> GetEmployeesWithDmAsync(int pageNumber, int pageSize, string sortBy, string sortOrder, string fields);
}
