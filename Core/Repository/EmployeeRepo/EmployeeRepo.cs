using EmployeeManagementSystemApi.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemApi.Core.Repository.EmployeeRepo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDbContext context;

        public EmployeeRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Task<List<Employee>> GetEmployees()
        {
            var employees = context.Employees.ToListAsync();
            return employees;
        }
    }
}
