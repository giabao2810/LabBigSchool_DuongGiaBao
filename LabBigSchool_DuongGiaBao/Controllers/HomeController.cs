using LabBigSchool_DuongGiaBao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using LabBigSchool_DuongGiaBao.ViewModels;

namespace LabBigSchool_DuongGiaBao.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext;

        public HomeController()
        {
            dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcommingCourses = dbContext.courses
                .Include(c => c.Lecturer)
                .Include(c => c.category)
                .Where(c => c.dateTime > DateTime.Now);
            return View(upcommingCourses);

            var viewModel = new CoursesViewModel
            {
                UpcommingCourses = upcommingCourses,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}