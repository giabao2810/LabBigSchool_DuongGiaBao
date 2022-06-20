using LabBigSchool_DuongGiaBao.Models;
using LabBigSchool_DuongGiaBao.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabBigSchool_DuongGiaBao.Controllers
{
    
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
       

        public CoursesController()
        {
            dbContext = new ApplicationDbContext();
        }
        // GET: Courses
     
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModels
            {
                categories = dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModels viewModels)
        {
            if (!ModelState.IsValid)
            {
                viewModels.categories = dbContext.Categories.ToList();
                return View("Create", viewModels);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                dateTime = viewModels.GetDateTime(),
                CategoryId = viewModels.Category,
                Place = viewModels.Place
            };
            dbContext.courses.Add(course);
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Attending()
        {
       
            {
                var userId = User.Identity.GetUserId();

                var courses = dbContext.Attendances
                    .Where(a => a.AttendeeId = userId)
                    .Select(a => a.Course)
                    .Include(l => l.Lecturer)
                    .Include(l => l.Category)
                    .ToList();
                var viewModel = new CoursesViewModel
                {
                    UpcommingCourses = courses,
                    ShowAction = User.Identity.IsAuthenticated
                };
                return View(viewModel);
         
            }
        }
    }
}   