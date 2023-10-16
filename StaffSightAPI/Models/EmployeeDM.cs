using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffSightAPI.Models
{
    [Table("EmployeeDM")]
    public class EmployeeDM
    {

        [Column("EmpID")]
        public string HrEmpID { get; set; }

        [Column("FirstName")]
        public string? HrFirstName { get; set; }

        [Column("LastName")]
        public string? HrLastName { get; set; }

        [Column("Location")]
        public string? HrLocation { get; set; }

        [Column("HireDate")]
        public DateTime? HrHireDate { get; set; }

        [Column("BilletNumber")]
        public string? HrBilletNumber { get; set; }

        [Column("SupervisorEmpID")]
        public string? HrSupervisorEmpID { get; set; }

        [Column("BranchID")]
        public string? HrBranchID { get; set; }

        [Column("EmployeeType")]
        public string? HrEmployeeType { get; set; }

        [Column("Vendor")]
        public string? HrVendor { get; set; }

        [Column("CurrentRow")]
        public int HrCurrentRow { get; set; }

        [NotMapped]
        public bool? HrIsContractor => HrEmployeeType == "Contractor";
    }
}
