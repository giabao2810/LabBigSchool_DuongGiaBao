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
        public IHttpActionResult Attend([FromBody] int courseID)
         
        {
            var attendance = new Attendance
            {
                CourseID = courseID,
                AttendeeID = User.Identity.GetUserId()
            };
            dbcontext.Attendances.Add(attendance);
            dbcontext.SaveChanges();

            return Ok();
        }

    }
}
