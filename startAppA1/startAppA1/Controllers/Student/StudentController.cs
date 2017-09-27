using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using startAppA1.Models.Student;

namespace startAppA1.Controllers.Student
{
    public class StudentController : Controller
    {
        // GET: Student
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult StudentHomeView()
        {
            return View();
        }
        public ActionResult StudentCourseView()
        {
            return View();
        }
        public ActionResult StudentLessonView()
        {
            return View();
        }
        public ActionResult StudentWorkView()
        {
            return View();
        }
        public ActionResult StudentGradeView()
        {
            return View();
        }
    }
}