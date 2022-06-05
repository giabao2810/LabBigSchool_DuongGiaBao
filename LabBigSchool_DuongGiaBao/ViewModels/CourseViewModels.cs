using LabBigSchool_DuongGiaBao.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabBigSchool_DuongGiaBao.ViewModels
{
    public class CourseViewModels
    {
       [Required]
        public String Place { get; set; }
        [Required]
        [FutureDate]
        public String Date { get; set;}
        [Required]
        [ValidTime]
        public String Time { get; set; }
        [Required]
        public byte Category { get; set; }
        public IEnumerable <Category> categories { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}