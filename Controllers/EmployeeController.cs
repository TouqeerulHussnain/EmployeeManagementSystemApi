using EmployeeManagementSystemApi.Core.Domain.Model;
using EmployeeManagementSystemApi.Core.Service.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }
        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetEmployees() { 
        
            var employees= await service.GetEmployees();
            return Ok(employees);
        
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateEmployee(Employee employee)
        {
            await service.CreateOrUpdateEmployee(employee);
            return Ok();
        }
    }
}
