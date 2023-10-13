using Microsoft.EntityFrameworkCore;
using StaffSightAPI.Models;

namespace StaffSightAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<EmployeePreHire> EmployeePreHires { get; set; }
        public DbSet<EmployeeNote> EmployeeNotes { get; set; }
        public DbSet<GenericDefinition> GenericDefinitions { get; set; }
        public DbSet<EmployeeSalOffHist> EmployeeSalOffHists { get; set; }
        public DbSet<EmployeeLeave> EmployeeLeaves { get; set; }
        public DbSet<TrainingClass> TrainingClasses { get; set; }
        public DbSet<ClassroomAssignment> ClassroomAssignments { get; set; }
        public DbSet<TrainerAssignment> TrainerAssignments { get; set; }
        public DbSet<TrainingActivity> TrainingActivities { get; set; }
        public DbSet<TrainingExclusion> TrainingExclusions { get; set; }
        public DbSet<ClassNameBuilder> ClassNameBuilders { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }
        public DbSet<ClassAttendance> ClassAttendances { get; set; }
        public DbSet<PreHireBillet> PreHireBillets { get; set; }


        // Additional DbSet properties for the other entities can be added here as needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Specific configurations or model relationships can be defined here.
            // For example, if you have special configurations for some tables or relationships, 
            // you would include them here.
        }
    }
}
