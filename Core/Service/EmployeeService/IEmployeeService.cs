using EmployeeManagementSystemApi.Core.Domain.Model;

namespace EmployeeManagementSystemApi.Core.Service.EmployeeService
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployees();
    }
}
