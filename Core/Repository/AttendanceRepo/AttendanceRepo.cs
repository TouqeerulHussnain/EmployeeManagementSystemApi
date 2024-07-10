
using EmployeeManagementSystemApi.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemApi.Core.Repository.AttendanceRepo
{
    public class AttendanceRepo : IAttendanceRepo
    {
        private readonly ApplicationDbContext context;

        public AttendanceRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task CheckIn(Guid employeeId, DateTime dateTime)
        {

            Attendance attendance = new Attendance
            {
                Date= DateTime.Now.Date,
                EmployeeId = employeeId,
                CheckInTime = dateTime,
            };
            await context.Attendances.AddAsync(attendance);
            await context.SaveChangesAsync();

        }

        public Task CheckOut(Guid employeeId, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Attendance>> GetAttendance()
        {
            return await context.Attendances.ToListAsync();
        }

        public async Task<List<Attendance>> GetAttendanceByDate(DateTime datetime)
        {
            var attendance = await context.Attendances.Where(element => element.Date == datetime).ToListAsync();

            var query = from Attendance in context.Attendances
                        join employee in context.Employees on Attendance.EmployeeId equals employee.Id
                        select new
                        {
                            AttendanceId = Attendance.Id,
                            EmployeeName = employee.Name,
                        };
            return attendance;

        }
        public async Task GetAttendanceJoined(DateTime datetime)
        {
            var query = from Attendance in context.Attendances
                        join employee in context.Employees on Attendance.EmployeeId equals employee.Id
                        select new
                        {
                            AttendanceId = Attendance,
                            EmployeeName = employee,
                        };
            query.ToList();

        }
    }
}
