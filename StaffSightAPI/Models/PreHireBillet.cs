#nullable disable
using System.ComponentModel.DataAnnotations;

namespace StaffSightAPI.Models
{
    public class PreHireBillet
    {
        [Key]
        public string BilletNumber { get; set; }
        public string PositionNumber { get; set; }
    }
}
