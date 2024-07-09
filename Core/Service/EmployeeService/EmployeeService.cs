using EmployeeManagementSystemApi.Core.Domain.Model;
using EmployeeManagementSystemApi.Core.Repository.EmployeeRepo;

namespace EmployeeManagementSystemApi.Core.Service.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo repo;

        public EmployeeService(IEmployeeRepo repo)
        {
            this.repo = repo;
        }

        public async Task CreateOrUpdateEmployee(Employee employee)
        {
           await repo.CreateOrUpdateEmployee(employee);
        }

        public Task<List<Employee>> GetEmployees()
        {
            return repo.GetEmployees();
        }
    }
}
