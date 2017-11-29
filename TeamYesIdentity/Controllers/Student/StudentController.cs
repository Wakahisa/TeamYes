using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeamYesIdentity.Models;

namespace TeamYesIdentity.Controllers.Student
{
    public class StudentController : Controller
    {
        // GET: Student
        //public ActionResult Index()
        //{
        //    return View();
        //}
        private Context db = new Context();

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
        public ActionResult StudentGradeView()
        {
            return View();
        }
        public ActionResult ResourcesView()
        {
            return View();
        }


        //Multiple Workviews needed for each student lesson
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
            model = db.WorkModels.FirstOrDefault(x => x.ID == 1);
            //}
            return View(model);
        }
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
            model = db.WorkModels.FirstOrDefault(x => x.ID == 1);
            //}
            return View(model);
        }

        //ActionResults for tables/multiple lessons
        public ActionResult LoadStudentCourses()
        {
            var model = db.StudentModels.ToList();
            return PartialView("_StudentCoursesTableView", model);
        }

        public PartialViewResult LoadStudentLesson1()
        {
            return PartialView("_StudentLesson1View");
        }

        public PartialViewResult LoadStudentLesson2()
        {
            return PartialView("_StudentLesson2View");
        }

        public PartialViewResult LoadStudentLesson3()
        {
            return PartialView("_StudentLesson3View");
        }
    }
}