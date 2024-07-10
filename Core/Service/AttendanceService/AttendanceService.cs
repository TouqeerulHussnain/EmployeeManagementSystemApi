

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
        public async Task CheckIn(Guid employeeId, DateTime dateTime)
        {
            await repo.CheckIn(employeeId, dateTime);
        }

        public Task CheckOut(Guid employeeId, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Domain.Model.Attendance>> GetAttendance()
        {
            return await repo.GetAttendance();
        }

        public async Task<List<Domain.Model.Attendance>> GetAttendanceByDate(DateTime datetime)
        {
            var attendence = await repo.GetAttendanceByDate(datetime);
            return attendence;
        }
    }
}
