#nullable disable
namespace StaffSightAPI.Models
{
    public class Shift
    {
        public int ShiftID { get; set; }
        public string DOA { get; set; }
        public DateTime HoaStart { get; set; }
        public DateTime HoaEnd { get; set; }
    }
}
