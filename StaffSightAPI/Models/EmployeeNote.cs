#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StaffSightAPI.Repositories.Implementations;

namespace StaffSightAPI.Models
{
    [Table("EmployeeNote")]
    public class EmployeeNote : IHasPreHireID
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
