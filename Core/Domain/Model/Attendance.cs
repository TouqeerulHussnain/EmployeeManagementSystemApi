namespace EmployeeManagementSystemApi.Core.Domain.Model
{
    public class Attendance
    {
        public Guid Id { get; set; }
        
        public DateTime? Date { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
