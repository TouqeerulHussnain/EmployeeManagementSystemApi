
using EmployeeManagementSystemApi.Core.Domain.Model;

namespace EmployeeManagementSystemApi.Core.Service.Attendance
{
    public interface IAttendanceService
    {
        public Task<List<Domain.Model.Attendance>> GetAttendance();
        public Task<List<Domain.Model.Attendance>> GetAttendanceByDate(DateTime datetime);
        public Task CheckIn(Guid employeeId, DateTime checkInTime, DateTime? date);
        public Task CheckOut(Guid employeeId, DateTime checkOutTime, DateTime? date);

        public Task AddAttendanceManually(Guid employeeId, DateTime checkInTime, DateTime date);
        public Task<bool> IsAttendanceAvailable(Guid employeeId, DateTime dateTime);
        
        public Task<bool> IsCheckInAvailable(Guid employeeId, DateTime checkInTime);
        public  Task<bool> IsCheckOutAvailable(Guid employeeId, DateTime AttendanceDate);
        public Task<Domain.Model.Attendance?> Attendance(Guid ofEmployee, DateTime ofDate);

        public Task<List<Domain.Model.Attendance>> GetAttendanceRange(DateTime start, DateTime end);

        public Task<List<Report>> GetAttendanceReportByDate(DateTime datetime);
    }
}
