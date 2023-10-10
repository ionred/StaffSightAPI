using System.ComponentModel.DataAnnotations;

namespace StaffSightAPI.Models
{
    public class Branch
    {
        [Key]
        public int BranchID { get; set; }
        [Required]
        public string BranchName { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}