#nullable disable
using StaffSightAPI.Repositories.Implementations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffSightAPI.Models
{
    [Table("EmployeeSalOffHist")]
    public class EmployeeSalOffHist: IHasPreHireID
    {
        [Key]
        public int SalaryID { get; set; }
        public int PreHireID { get; set; }
        public decimal Salary { get; set; }
        public string SalaryType { get; set; }
        public DateTime EnteredDate { get; set; }
        public string EnteredBy { get; set; }
        public string Note { get; set; }
    }
}
