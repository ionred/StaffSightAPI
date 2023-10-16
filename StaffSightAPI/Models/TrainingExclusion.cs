#nullable disable
using System.ComponentModel.DataAnnotations;

namespace StaffSightAPI.Models
{
    public class TrainingExclusion
    {
        [Key] public int TrainingExclusionID { get; set; }
        public DateTime ExclusionDate { get; set; }
        public int TrainingClassID { get; set; }
    }
}
