using EmployeeManagementSystemApi.Core.Service.Attendance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService service;

        public AttendanceController(IAttendanceService service)
        {
            this.service = service;
        }


        [HttpPost("CheckIn")]
        public async Task<IActionResult> CheckIn(Guid empId, DateTime checkInTime)
        {
            await service.CheckIn (empId, checkInTime);
            return Ok();
        }
        [HttpGet("GetAttendance")]
        public async Task<IActionResult> GetAttendance()
        {
            var attendance= await service.GetAttendance();
            return Ok(attendance);
        }
        [HttpGet("GetAttendanceByDate")]
        public async Task<IActionResult> GetAttendanceByDate(DateTime dateTime)
        {
            var attendance = await service.GetAttendanceByDate(dateTime);
            return Ok(attendance);
        }
    }
}
