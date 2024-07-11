using EmployeeManagementSystemApi.Core.Domain.Model;

namespace EmployeeManagementSystemApi.Core.Repository.AttendanceRepo
{
    public interface IAttendanceRepo
    {
        public  Task<Attendance?> Attendance(Guid ofEmployee, DateTime ofDate);
        public Task<Attendance> CheckIn(Guid employeeId, DateTime checkInTime);
        public Task<Attendance> CheckOut(Guid employeeId, DateTime checkOutTime);
        public Task AddAttendanceManually(Guid employeeId, DateTime checkInTime, DateTime date);
        public Task<List<Report>> GetAttendanceReportByDate(DateTime datetime);
        
        public Task<List<Attendance>> GetAttendanceRange(DateTime start, DateTime end);
    }
}
