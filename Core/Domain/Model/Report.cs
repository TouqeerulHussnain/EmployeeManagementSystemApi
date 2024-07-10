namespace EmployeeManagementSystemApi.Core.Domain.Model
{
    public class Report
    {
       public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        
    }
}
