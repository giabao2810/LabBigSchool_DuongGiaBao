using LabBigSchool_DuongGiaBao.DTOs;
using LabBigSchool_DuongGiaBao.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabBigSchool_DuongGiaBao.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext dbcontext;

        public AttendancesController()
        {
            dbcontext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
         
        {
            var userId = User.Identity.GetUserId();
            if (dbcontext.Attendances.Any(a => a.AttendeeId == userId && a.CourseID == attendanceDto.CourseId))
                return BadRequest("the Attendance already exists!");
            var attendance = new Attendance
            {
                CourseID = attendanceDto.CourseId,
                AttendeeId = userId
            };
            dbcontext.Attendances.Add(attendance);
            dbcontext.SaveChanges();

            return Ok();
        }

    }
}
