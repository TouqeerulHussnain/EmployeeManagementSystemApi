using EmployeeManagementSystemApi.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystemApi.Core.Domain.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasIndex(x => new { x.Date, x.EmployeeId}).IsUnique();  
        }
    }
}
