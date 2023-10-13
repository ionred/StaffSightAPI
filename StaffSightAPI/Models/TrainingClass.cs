#nullable disable
namespace StaffSightAPI.Models
{
    public class TrainingClass
    {
        public int TrainingClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassType { get; set; }
        public int LocationID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string EmployeeType { get; set; }
        public int TargetHeadcount { get; set; }
        public bool IsNEO { get; set; }
    }
}
