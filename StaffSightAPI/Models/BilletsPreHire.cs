using System.ComponentModel.DataAnnotations;

namespace StaffSightAPI.Models
{
    public class BilletsPreHire
    {
        [Key]
        public int BilletID { get; set; }
        [Required]
        public string BilletNumber { get; set; } = string.Empty;
        public string PositionNumber { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
