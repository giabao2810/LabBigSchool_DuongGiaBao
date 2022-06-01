using LabBigSchool_DuongGiaBao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabBigSchool_DuongGiaBao.ViewModels
{
    public class CourseViewModels
    {
        public String Place { get; set; }
        public String Date { get; set;}
        public String Time { get; set; }

        public byte Category { get; set; }
        public IEnumerable <Category> categories { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}