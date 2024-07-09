namespace EmployeeManagementSystemApi.Core.Domain.Model
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
         public Attendance Attendance { get; set; }
    }
}
