
namespace EmployeeManagementSystemApi.Core.Service.Attendance
{
    public interface IAttendanceService
    {
        public Task<List<Domain.Model.Attendance>> GetAttendance();
        public Task<List<Domain.Model.Attendance>> GetAttendanceByDate(DateTime datetime);
        public Task CheckIn(Guid employeeId, DateTime dateTime);
        public Task CheckOut(Guid employeeId, DateTime dateTime);
    }
}
