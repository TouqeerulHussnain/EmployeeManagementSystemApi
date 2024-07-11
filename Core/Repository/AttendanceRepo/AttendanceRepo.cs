
using EmployeeManagementSystemApi.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagementSystemApi.Core.Repository.AttendanceRepo
{
    public class AttendanceRepo : IAttendanceRepo
    {
        private readonly ApplicationDbContext context;

        public AttendanceRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddAttendanceManually(Guid employeeId, DateTime checkInTime, DateTime date)
        {
            Attendance attendance = new Attendance
            {
                Date = date.Date,
                EmployeeId = employeeId,
                CheckInTime = checkInTime,
            };
            await context.Attendances.AddAsync(attendance);
            await context.SaveChangesAsync();

        }

        public async Task<Attendance> CheckIn(Guid employeeId, DateTime checkInTime)
        {
            Attendance attendance = new Attendance
            {
                Date = DateTime.Now.Date,
                EmployeeId = employeeId,
                CheckInTime = checkInTime,
            };
            await context.Attendances.AddAsync(attendance);
            await context.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance> CheckOut(Guid employeeId, DateTime checkOutTime)
        {
            var list = await context.Attendances.AsNoTracking().ToListAsync();
            var attendance = list.Where(e => e.EmployeeId == employeeId && e.Date == DateTime.Now.Date).FirstOrDefault();
            if (attendance != null)
            {
                attendance.CheckOutTime = checkOutTime;
                context.Attendances.Update(attendance);
                await context.SaveChangesAsync();
                return attendance;
            }
            
            return attendance;
        }

        public async Task<List<Attendance>> GetAttendance()
        {
            return await context.Attendances.ToListAsync();
        }

        public async Task<List<Attendance>> GetAttendanceRange(DateTime start, DateTime end)
        {
            var list = await context.Attendances.Where(e => e.Date >= start && e.Date <= end).ToListAsync();
            return list;
        }

        public async Task<List<Attendance>> GetAttendanceByDate(DateTime datetime)
        {
            var attendance = await context.Attendances.Where(element => element.Date == datetime).ToListAsync();
            return attendance;

        }
        public async Task<Attendance?> Attendance(Guid ofEmployee, DateTime ofDate)
        {
            var attendance = await context.Attendances.AsNoTracking().ToListAsync();
            var val = attendance.Where(e => e.EmployeeId == ofEmployee && e.Date == ofDate.Date).FirstOrDefault();
            return val;
        }


        public async Task<List<Report>> GetAttendanceReportByDate(DateTime datetime)
        {
            var query = await (from e in context.Employees
                               join a in context.Attendances on e.Id equals a.EmployeeId
                               into attendances
                               from a in attendances.DefaultIfEmpty()
                               where a == null || a.Date == datetime || e.Attendance==null
                               select new Report
                               {
                                   EmployeeId = e.Id,
                                   Name = e.Name,
                                   AttendanceDate = a.Date,
                                   CheckInTime = a.CheckInTime,
                                   CheckOutTime = a.CheckOutTime
                               }).ToListAsync();


            return query;
        }
    }
}
