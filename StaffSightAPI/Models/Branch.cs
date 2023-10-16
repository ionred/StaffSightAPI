#nullable disable

using System.ComponentModel.DataAnnotations;

namespace StaffSightAPI.Models
{
    public class Branch
    {

        [Key]
        [Required]
        public string BranchID { get; set; }
        [Required] 
        public string BranchName { get; set; }
    }
}
