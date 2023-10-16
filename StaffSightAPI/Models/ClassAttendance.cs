#nullable disable
using System.ComponentModel.DataAnnotations;

namespace StaffSightAPI.Models
{
    public class ClassAttendance
    {
        [Key]
        public int ClassAttendanceID { get; set; }
        public int TrainingClassID { get; set; }
        public string EmpID { get; set; }
        public string ReportingEmpID { get; set; }
        public string AttendanceType { get; set; }
        public DateTime IncidentDate { get; set; }
        public bool IsPreApproved { get; set; }
        public DateTime TimeNotified { get; set; }
    }
}
