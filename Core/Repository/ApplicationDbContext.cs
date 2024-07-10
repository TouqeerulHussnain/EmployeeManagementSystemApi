using EmployeeManagementSystemApi.Core.Domain.Configurations;
using EmployeeManagementSystemApi.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemApi.Core.Repository
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AttendanceConfiguration());
        }
    }
}
