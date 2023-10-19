#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffSightAPI.Models
{
    [Table("GenericDefinition")]
    public class GenericDefinition
    {
        [Key]
        public int DefinitionID { get; set; }
        public string DefinitionType { get; set; }
        public string DefinitionValue { get; set; }
    }
}
