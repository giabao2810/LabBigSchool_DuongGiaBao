using LabBigSchool_DuongGiaBao.DTOs;
using LabBigSchool_DuongGiaBao.Models;
using Microsoft.AspNet.Identity;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LabBigSchool_DuongGiaBao.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext dbContext;
        public FollowingsController()
        {
            dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest(" Following already exists!");
            var folowing = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };
            dbContext.Followings.Add(folowing);
            dbContext.SaveChanges();
        }



    }
}