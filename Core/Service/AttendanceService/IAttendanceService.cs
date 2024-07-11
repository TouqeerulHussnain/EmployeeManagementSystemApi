
using EmployeeManagementSystemApi.Core.Domain.Model;

namespace EmployeeManagementSystemApi.Core.Service.Attendance
{
    public interface IAttendanceService
    {
        public Task<List<Domain.Model.Attendance>> GetAttendance();
        public Task<List<Domain.Model.Attendance>> GetAttendanceByDate(DateTime datetime);
        public Task<Domain.Model.Attendance> CheckIn(Guid employeeId, DateTime checkInTime);
        public Task<Domain.Model.Attendance> CheckOut(Guid employeeId, DateTime checkOutTime);

        public Task AddAttendanceManually(Guid employeeId, DateTime checkInTime, DateTime date);
        
        public Task<Domain.Model.Attendance?> Attendance(Guid ofEmployee, DateTime ofDate);

        public Task<List<Domain.Model.Attendance>> GetAttendanceRange(DateTime start, DateTime end);

        public Task<List<Report>> GetAttendanceReportByDate(DateTime datetime);
    }
}
