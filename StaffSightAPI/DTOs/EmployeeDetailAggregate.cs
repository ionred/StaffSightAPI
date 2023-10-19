using StaffSightAPI.Models;

namespace StaffSightAPI.DTOs
{
    public class EmployeeDetailAggregate
    {
        public EmployeeDto Employee { get; set; }
        public List<EmployeeSalOffHist>? SalaryInformation { get; set; }
        public List<EmployeeNote>? Notes { get; set; }
    }
}
