using System;
using System.ComponentModel.DataAnnotations;

namespace StaffSightAPI.Models
{
    public class EmployeePreHire
    {
        private string _empID;
        [Key]
        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "EmpID must be between 5 and 10 characters.")]
        [RegularExpression(@"^[A-Za-z0-9][0-9]{4,9}$", ErrorMessage = "EmpID must start with [A-Z, a-z, 0-9] followed by 4 to 9 numeric characters.")]
        public string EmpID
        {
            get => _empID;
            set => _empID = value?.ToUpper();
        }


        [Required]
        [StringLength(75)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(75)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(75)]
        public string? AddressFirst { get; set; }

        [StringLength(75)]
        public string? AddressSecond { get; set; }

        [StringLength(75)]
        public string? City { get; set; }

        [StringLength(75)]
        public string? State { get; set; }

        public int? Zip { get; set; }

        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        [StringLength(150)]
        public string? EmailAddress { get; set; }

        [StringLength(75)]
        public string? BilletNumber { get; set; }

        [StringLength(75)]
        public string? LocationName { get; set; }

        public int? BranchID { get; set; }

        public DateTime? ExpectedHireDate { get; set; }

        public bool? IsContractor { get; set; }

        public bool? IsConversion { get; set; }

        [StringLength(10)]
        public string? AssignedTA { get; set; }
    }
}
