#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffSightAPI.Models
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public bool ClassOnly { get; set; }
    }
}
