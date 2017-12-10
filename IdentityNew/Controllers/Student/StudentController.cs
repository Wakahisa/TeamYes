using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IdentityNew.Models;

namespace IdentityNew.Controllers.Student
{
    public class StudentController : Controller
    {
        // GET: Student
        //public ActionResult Index()
        //{
        //    return View();
        //}
        private Context db = new Context();

        [Authorize(Roles = "Student, Admin")]
        public ActionResult StudentHomeView()
        {
            var model = new CourseModel();

            model = db.CourseModels.FirstOrDefault(x => x.ID == 1);
            return View(model);
        }

        [Authorize(Roles = "Student, Admin")]
        public ActionResult StudentCourseView()
        {
            return View();
        }

        [Authorize(Roles = "Student, Admin")]
        public ActionResult StudentLessonView()
        {
            return View();
        }

        [Authorize(Roles = "Student, Admin")]
        public ActionResult StudentGradeView()
        {
            return View();
        }

        [Authorize(Roles = "Student, Admin")]
        public ActionResult ResourcesView()
        {
            return View();
        }

        [Authorize(Roles = "Student, Admin")]
        public ActionResult StudentWorkView()
        // public ActionResult StudentWorkView(int workID)
        {
            var model = new WorkModel();
            //if (workID > 0)
            //{
            //    model = db.WorkModels.FirstOrDefault(x => x.ID == workID);
            //}
            //else
            //{
                model = db.WorkModels.FirstOrDefault(x => x.ID == 1);
            //}
            return View(model);
        }

        [Authorize(Roles = "Student, Admin")]
        public ActionResult StudentWorkView2()
        // public ActionResult StudentWorkView(int workID)
        {
            var model = new WorkModel();
            //if (workID > 0)
            //{
            //    model = db.WorkModels.FirstOrDefault(x => x.ID == workID);
            //}
            //else
            //{
            model = db.WorkModels.FirstOrDefault(x => x.ID == 2);
            //}
            return View(model);
        }

        [Authorize(Roles = "Student, Admin")]
        public ActionResult StudentWorkView3()
        // public ActionResult StudentWorkView(int workID)
        {
            var model = new WorkModel();
            //if (workID > 0)
            //{
            //    model = db.WorkModels.FirstOrDefault(x => x.ID == workID);
            //}
            //else
            //{
            model = db.WorkModels.FirstOrDefault(x => x.ID == 3);
            //}
            return View(model);
        }


        //ActionResults for tables/multiple lessons
        [Authorize(Roles = "Student, Admin")]
        public ActionResult LoadStudentCourses()
        {
            var model = db.StudentModels.ToList();
            return PartialView("_StudentCoursesTableView", model);
        }

        [Authorize(Roles = "Student, Admin")]
        public PartialViewResult LoadStudentLesson1()
        {
            return PartialView("_StudentLesson1View");
        }

        [Authorize(Roles = "Student, Admin")]
        public PartialViewResult LoadStudentLesson2()
        {
            return PartialView("_StudentLesson2View");
        }

        [Authorize(Roles = "Student, Admin")]
        public PartialViewResult LoadStudentLesson3()
        {
            return PartialView("_StudentLesson3View");
        }
    }
}