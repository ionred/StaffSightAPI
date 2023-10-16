#nullable disable
using System.ComponentModel.DataAnnotations;

namespace StaffSightAPI.Models
{
    public class ClassNameBuilder
    {
        [Key]
        public int ClassNameBuilderID { get; set; }
        public string CodeName { get; set; }
        public string CodeType { get; set; }
    }
}
