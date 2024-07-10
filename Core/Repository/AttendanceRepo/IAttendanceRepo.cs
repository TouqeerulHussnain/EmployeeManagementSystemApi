using EmployeeManagementSystemApi.Core.Domain.Model;

namespace EmployeeManagementSystemApi.Core.Repository.AttendanceRepo
{
    public interface IAttendanceRepo
    {
        public Task<List<Attendance>> GetAttendance();
        public Task<List<Attendance>> GetAttendanceByDate(DateTime datetime);
        public Task CheckIn(Guid employeeId, DateTime dateTime);
        public Task CheckOut(Guid employeeId, DateTime dateTime);
    }
}
