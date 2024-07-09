using EmployeeManagementSystemApi.Core.Domain.Model;

namespace EmployeeManagementSystemApi.Core.Repository.EmployeeRepo
{
    public interface IEmployeeRepo
    {
        public  Task<List<Employee>> GetEmployees();

        public Task CreateOrUpdateEmployee(Employee employee);
    }
}
