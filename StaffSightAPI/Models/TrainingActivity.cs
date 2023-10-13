#nullable disable
namespace StaffSightAPI.Models
{
    public class TrainingActivity
    {
        public int TrainingActivityID { get; set; }
        public string ActivityName { get; set; }
        public DateTime ActDate { get; set; }
        public int TrainingClassID { get; set; }
    }
}
