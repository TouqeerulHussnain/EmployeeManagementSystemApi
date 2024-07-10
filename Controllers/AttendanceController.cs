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
        public async Task<IActionResult> CheckIn(Guid empId, DateTime checkInTime, DateTime? forDate)
        {

            DateTime AttendanceDate = forDate ?? DateTime.Now.Date;


            bool attendanceAvailable = await service.IsAttendanceAvailable(empId, AttendanceDate);
            if (attendanceAvailable)
            {
                bool alreadyCheckIn = await service.IsCheckInAvailable(empId, checkInTime);
                if (alreadyCheckIn)
                {
                    return BadRequest("You already Checked In for this date");
                }
                else
                {
                    await service.CheckIn(empId, checkInTime, forDate);
                }

            }
            else
            {
                await service.CheckIn(empId, checkInTime, forDate);
            }

            return Ok();
        }

        [HttpPost("CheckOut")]
        public async Task<IActionResult> CheckOut(Guid empId, DateTime checkOutTime, DateTime? forDate)
        {

            DateTime AttendanceDate = forDate ?? DateTime.Now.Date;
            bool attendanceAvailable = await service.IsAttendanceAvailable(empId, AttendanceDate);
            if (attendanceAvailable)
            {
                bool alreadyCheckIn = await service.IsCheckInAvailable(empId, AttendanceDate);
                if (alreadyCheckIn)
                {
                    bool isCheckOutAlready = await service.IsCheckOutAvailable(empId, AttendanceDate);
                    if (isCheckOutAlready)
                    {
                        return BadRequest("You already Checkout");
                    }
                    else
                    {

                        await service.CheckOut(empId, checkOutTime, forDate);
                    }
                }
                else
                {
                    return BadRequest("You have to check in first");
                }

            }
            else
            {
                return BadRequest("You have to check in first");
            }

            return Ok();
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