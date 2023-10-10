using Microsoft.EntityFrameworkCore;
using StaffSightAPI.Models;

namespace StaffSightAPI.Data
{
    public class StaffSightContext : DbContext
    {
        public StaffSightContext(DbContextOptions<StaffSightContext> options) : base(options)
        {
        }

        public DbSet<EmployeePreHire> EmployeePreHires { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BilletsPreHire> BilletsPreHires { get; set; }

        // Additional DbSet properties for other models will be added here later
    }
}
