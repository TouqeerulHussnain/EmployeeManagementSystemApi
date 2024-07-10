using EmployeeManagementSystemApi.Core.Domain.Model;

namespace EmployeeManagementSystemApi.Core.Repository.AttendanceRepo
{
    public interface IAttendanceRepo
    {
        public Task<List<Attendance>> GetAttendance();
        public Task<List<Attendance>> GetAttendanceByDate(DateTime datetime);
        public Task CheckIn(Guid employeeId, DateTime checkInTime, DateTime? date);
        public Task CheckOut(Guid employeeId, DateTime checkOutTime, DateTime? date);
        public Task AddAttendanceManually(Guid employeeId, DateTime checkInTime, DateTime date);

        public Task<bool> IsAttendanceAvailable(Guid employeeId, DateTime dateTime);
        public  Task<bool> IsCheckInAvailable(Guid employeeId, DateTime checkInTime);
        public  Task<bool> IsCheckOutAvailable(Guid employeeId, DateTime AttendanceDate)
    }
}
