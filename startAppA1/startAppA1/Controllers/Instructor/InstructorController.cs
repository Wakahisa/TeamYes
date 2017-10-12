using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace startAppA1.Controllers.Instructor
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult InstructorHomeView()
        {
            return View();
        }
        public ActionResult InstructorCourseCreationView()
        {
            return View();
        }
        public ActionResult InstructorCourseEditView()
        {
            return View();
        }
        public ActionResult InstructorCourseManagementView()
        {
            return View();
        }
        public ActionResult InstructorLessonEditView()
        {
            return View();
        }
        public ActionResult InstructorLessonManagementView()
        {
            return View();
        }
        public ActionResult InstructorStudentManagementView()
        {
            return View();
        }
    }
}