using EmployeeManagementSystemApi.Core.Domain.Model;
using EmployeeManagementSystemApi.Core.Service.Attendance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

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

            try
            {
                Attendance checkIn = await service.CheckIn(empId, checkInTime);
                return Ok(checkIn);
            }
            catch (Exception e) {
                return BadRequest("Already Checked In");
            }
        }

        [HttpPost("CheckOut")]
        public async Task<IActionResult> CheckOut(Guid empId, DateTime checkOutTime)
        {

            Attendance? attendance = await service.Attendance(empId, DateTime.Now.Date);
            if (attendance != null && attendance.CheckOutTime == null) 
            { 
                Attendance checkout=  await service.CheckOut(empId, checkOutTime);
                return Ok(checkout);
            }
            else if(attendance != null && attendance.CheckOutTime != null)
            {
                return BadRequest("Already Checked out");
            }
            else
            {
                return BadRequest("Please check in first");
            }

        }




        [HttpPost("AddAttendanceManually")]
        public async Task<IActionResult> AddAttendanceManually(Guid empId, DateTime date, DateTime checkInTime)
        {
            await service.AddAttendanceManually(empId, checkInTime, date);
            return Ok();
        }




        [HttpGet("GetAttendance")]
        public async Task<IActionResult> GetAttendance()
        {
            var attendance = await service.GetAttendance();
            return Ok(attendance);
        }




        [HttpGet("GetAttendanceByDate")]
        public async Task<IActionResult> GetAttendanceByDate(DateTime dateTime)
        {
            var attendance = await service.GetAttendanceByDate(dateTime);
            return Ok(attendance);
        }




        [HttpGet("GetAttendanceReportByDate")]
        public async Task<IActionResult> GetAttendanceReportByDate(DateTime dateTime)
        {
            var attendance = await service.GetAttendanceReportByDate(dateTime);
            return Ok(attendance);
        }




        [HttpGet("GetAttendanceFrom")]
        public async Task<IActionResult> GetAttendanceFrom(DateTime start, DateTime end)
        {
            var list = await service.GetAttendanceRange(start, end);
            return Ok(list);
        }
    }

    
}