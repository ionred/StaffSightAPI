#nullable disable
using System.ComponentModel.DataAnnotations;

namespace StaffSightAPI.Models
{
    public class AuditTrail
    {
        [Key]
        public int AuditTrailID { get; set; }
        public string ModuleUsed { get; set; }
        public string TableName { get; set; }
        public int TableRowID { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public bool RecordDeleted { get; set; }
        public string ChangedByEmpID { get; set; }
        public bool IsConfidential { get; set; }
    }
}
