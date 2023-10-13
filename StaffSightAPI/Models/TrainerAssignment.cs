#nullable disable
namespace StaffSightAPI.Models
{
    public class TrainerAssignment
    {
        public int TrainerAssignmentID { get; set; }
        public string EmpID { get; set; }
        public int TrainingClassID { get; set; }
        public string TrainerType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
