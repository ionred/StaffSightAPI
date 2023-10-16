#nullable disable
using System.ComponentModel.DataAnnotations;

namespace StaffSightAPI.Models
{
    public class GenericDefinition
    {
        [Key]
        public int DefinitionID { get; set; }
        public string DefinitionType { get; set; }
        public string DefinitionValue { get; set; }
    }
}
