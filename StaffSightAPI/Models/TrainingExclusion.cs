#nullable disable
namespace StaffSightAPI.Models
{
    public class TrainingExclusion
    {
        public int TrainingExclusionID { get; set; }
        public DateTime ExclusionDate { get; set; }
        public int TrainingClassID { get; set; }
    }
}
