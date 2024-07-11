

using EmployeeManagementSystemApi.Core.Domain.Model;
using EmployeeManagementSystemApi.Core.Repository.AttendanceRepo;

namespace EmployeeManagementSystemApi.Core.Service.Attendance
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepo repo;

        public AttendanceService(IAttendanceRepo repo)
        {
            this.repo = repo;
        }

        public async Task AddAttendanceManually(Guid employeeId, DateTime checkInTime, DateTime date)
        {
            await repo.AddAttendanceManually(employeeId, checkInTime, date);
        }

        public async Task<Domain.Model.Attendance?> Attendance(Guid ofEmployee, DateTime ofDate)
        {
            var attendance = await repo.Attendance(ofEmployee, ofDate);
            return attendance;
        }

        public async Task<Domain.Model.Attendance> CheckIn(Guid employeeId, DateTime checkInTime)
        {
            return await repo.CheckIn(employeeId,checkInTime);
        }

        public async Task<Domain.Model.Attendance> CheckOut(Guid employeeId, DateTime checkOutTime)
        {
            return await repo.CheckOut(employeeId,checkOutTime);
        }

        

        public async Task<List<Domain.Model.Attendance>> GetAttendanceRange(DateTime start, DateTime end)
        {
            var list = await repo.GetAttendanceRange(start, end);
            return list;
        }

        public async Task<List<Report>> GetAttendanceReportByDate(DateTime datetime)
        {
            var list = await repo.GetAttendanceReportByDate (datetime);
            return list;
        }

       
    }
}
