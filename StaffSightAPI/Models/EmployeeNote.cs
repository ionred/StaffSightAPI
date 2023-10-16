#nullable disable
using System.ComponentModel.DataAnnotations;

namespace StaffSightAPI.Models
{
    public class EmployeeNote
    {
        [Key]
        public int EmployeeNoteID { get; set; }
        public int PreHireID { get; set; }
        public string Note { get; set; }
        public bool IsConfidential { get; set; }
        public DateTime EnteredDate { get; set; }
        public string EnteredBy { get; set; }
    }
}
