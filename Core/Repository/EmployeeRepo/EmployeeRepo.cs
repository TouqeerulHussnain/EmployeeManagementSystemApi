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

        public async Task CreateOrUpdateEmployee(Employee employee)
        {
            var employees = context.Employees;
            await employees.AddAsync(employee);
            await context.SaveChangesAsync();

        }

        public async Task DeleteEmployee(Guid id)
        {
            var employees = await context.Employees.ToListAsync();
            var delEmployee = employees.Where(element => element.Id == id).First();
            context.Employees.Remove(delEmployee!);
            await context.SaveChangesAsync();
        }

        public async Task<Employee?> GetEmployeeById(Guid id)
        {
            var employees = await context.Employees.ToListAsync();
            var availableEmployee = employees.Where(element => element.Id == id).FirstOrDefault();
            if (availableEmployee != null)
            {
               return availableEmployee;

            }
            else
            {
                return null;
            }
        }

        public Task<List<Employee>> GetEmployees()
        {
            var employees = context.Employees.ToListAsync();
            return employees;
        }
    }
}
