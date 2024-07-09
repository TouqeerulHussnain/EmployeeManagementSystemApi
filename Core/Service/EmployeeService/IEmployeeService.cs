using EmployeeManagementSystemApi.Core.Domain.Model;

namespace EmployeeManagementSystemApi.Core.Service.EmployeeService
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployees();
        public Task CreateOrUpdateEmployee(Employee employee);
        public  Task DeleteEmployee(Guid id);
        public Task<Employee?> GetEmployeeById(Guid id);
        public Task Update(Employee employee);
    }
}
