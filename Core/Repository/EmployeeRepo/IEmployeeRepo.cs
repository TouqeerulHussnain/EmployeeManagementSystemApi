using EmployeeManagementSystemApi.Core.Domain.Model;

namespace EmployeeManagementSystemApi.Core.Repository.EmployeeRepo
{
    public interface IEmployeeRepo
    {
        public  Task<List<Employee>> GetEmployees();
        public Task CreateOrUpdateEmployee(Employee employee);
        public Task Update(Employee employee);
        public Task DeleteEmployee(Guid id);
        public Task<Employee?> GetEmployeeById(Guid id);
    }
}
