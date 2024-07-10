
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

        public async Task CheckIn(Guid employeeId, DateTime checkInTime, DateTime? date)
        {
            DateTime currentDate = date ?? DateTime.Now;
            Attendance attendance = new Attendance
            {
                Date = currentDate.Date,
                EmployeeId = employeeId,
                CheckInTime = checkInTime,
            };
            await context.Attendances.AddAsync(attendance);
            await context.SaveChangesAsync();

        }

        public async Task CheckOut(Guid employeeId, DateTime checkOutTime, DateTime? date)
        {
            DateTime forDate = date ?? DateTime.Now.Date;
            var list = await context.Attendances.AsNoTracking().ToListAsync();
            var empAttendance = list.Where(e => e.EmployeeId == employeeId && e.Date == forDate.Date).FirstOrDefault();
            if (empAttendance != null)
            {
                empAttendance.CheckOutTime = checkOutTime;
                context.Attendances.Update(empAttendance);
            }
            await context.SaveChangesAsync();
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
            var val = attendance.Where(e => e.EmployeeId == ofEmployee && e.Date == ofDate).FirstOrDefault();
            return val;
        }

        public async Task<bool> IsAttendanceAvailable(Guid employeeId, DateTime AttendanceDate)
        {
            var attendance = await context.Attendances.AsNoTracking().ToListAsync();
            var val = attendance.Where(e => e.EmployeeId == employeeId && e.Date == AttendanceDate).FirstOrDefault();

            if (val != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> IsCheckInAvailable(Guid employeeId, DateTime AttendanceDate)
        {
            var attendance = await context.Attendances.AsNoTracking().ToListAsync();
            var val = attendance.Where(e => e.EmployeeId == employeeId && e.Date == AttendanceDate).FirstOrDefault();

            if (val.CheckInTime != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> IsCheckOutAvailable(Guid employeeId, DateTime AttendanceDate)
        {
            var attendance = await context.Attendances.AsNoTracking().ToListAsync();
            var val = attendance.Where(e => e.EmployeeId == employeeId && e.Date == AttendanceDate).FirstOrDefault();

            if (val.CheckOutTime != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Report>> GetAttendanceReportByDate(DateTime datetime)
        {
            var query = await (from e in context.Employees
                               join a in context.Attendances on e.Id equals a.EmployeeId
                               into attendances
                               from a in attendances.DefaultIfEmpty()
                               where a == null || a.Date == datetime
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
