#nullable disable
namespace StaffSightAPI.Models
{
    public class EmployeeSalOffHist
    {
        public int SalaryID { get; set; }
        public int PreHireID { get; set; }
        public decimal Salary { get; set; }
        public string SalaryType { get; set; }
        public DateTime EnteredDate { get; set; }
        public string EnteredBy { get; set; }
        public string Note { get; set; }
    }
}
