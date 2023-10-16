#nullable disable
using System.ComponentModel.DataAnnotations;

namespace StaffSightAPI.Models
{
    public class ClassroomAssignment
    {
        [Key]
        public int ClassroomAssignmentID { get; set; }
        public string RoomType { get; set; }
        public string RoomLocation { get; set; }
        public string RoomID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int TrainingClassID { get; set; }
    }
}
