﻿using System.ComponentModel.DataAnnotations;

namespace StaffSightAPI.DTOs
{
    public class EmployeePreHireUpdateDto
    {
        [StringLength(10, MinimumLength = 5, ErrorMessage = "EmpID must be between 5 and 10 characters.")]
        [RegularExpression(@"^[A-Za-z0-9][0-9]{4,9}$", ErrorMessage = "EmpID must start with [A-Z, a-z, 0-9] followed by 4 to 9 numeric characters.")]
        public string? EmpID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Location { get; set; }
        public string? AddressOne { get; set; }
        public string? AddressTwo { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? Zip { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PhoneExtension { get; set; }
        public string? PhoneType { get; set; }
        public string? PersonalEmail { get; set; }
        public DateTime? HireDate { get; set; }
        public string? BranchID { get; set; }
        public string? BilletNumber { get; set; }
        public string? SupervisorEmpID { get; set; }
        public string? StfAsstEmpID { get; set; }
        public int? ShiftID { get; set; }
        public string? Vendor { get; set; }
        public string? ReqID { get; set; }
        public string? CostCenter { get; set; }
        public string? Isp { get; set; }
        public string? IspOther { get; set; }
        public bool? Ethernet { get; set; }
        public string? Ritm { get; set; }
        public string? ActivationID { get; set; }
        public string? CiscoNumber { get; set; }
        public bool? IsContractor { get; set; }
        public bool? IsConversion { get; set; }
    }
}
