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
    }
}
