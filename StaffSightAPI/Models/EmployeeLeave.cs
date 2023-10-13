#nullable disable
using System.ComponentModel.DataAnnotations;

namespace StaffSightAPI.Models
{
    public class EmployeeLeave
    {
        [Required] 
        public string EmpID { get; set; }
        [Required]
        public DateTime LeaveDate { get; set; }
        [Required] 
        public DateTime EnteredDate { get; set; }
        [Required] 
        public string EnteredBy { get; set; }
        
        public string Note { get; set; }
    }
}
