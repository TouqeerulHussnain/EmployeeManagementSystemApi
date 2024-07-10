

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

        public async Task CheckIn(Guid employeeId, DateTime checkInTime, DateTime? date)
        {
            await repo.CheckIn(employeeId,checkInTime,date);
        }

        public async Task CheckOut(Guid employeeId, DateTime checkOutTime, DateTime? date)
        {
            await repo.CheckOut(employeeId,checkOutTime,date);
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

        public async Task<bool> IsAttendanceAvailable(Guid employeeId, DateTime dateTime)
        {
           bool val =  await repo.IsAttendanceAvailable( employeeId, dateTime);
            return val;
        }
        
        public async Task<bool> IsCheckInAvailable(Guid employeeId, DateTime checkInTime)
        {
            bool val = await repo.IsCheckInAvailable( employeeId, checkInTime);
            return val;
        }

        public async Task<bool> IsCheckOutAvailable(Guid employeeId, DateTime AttendanceDate)
        {
            bool val = await repo.IsCheckOutAvailable( employeeId, AttendanceDate);
            return val;
        }
    }
}
