using startAppA1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace startAppA1.Controllers.Instructor
{

    public class InstructorController : Controller
    {
        private Context db = new Context();

        // GET: Instructor
        public ActionResult InstructorHomeView()
        {
            return View();
        }
        public ActionResult InstructorCourseCreationView()
        {
            return View();
        }

#region Lesson Edit

        /// <summary>
        /// loads lesson edit
        /// </summary>
        /// <returns></returns>
        public ActionResult InstructorLessonEditView(int? lessonID)
        {
            var model = new LessonCreateViewModel();
            if (lessonID > 0)
            {
                model.Load(db.LessonModels.First(f => f.ID == lessonID));
            }
            else
            {
                model.Load(db.LessonModels.FirstOrDefault());
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult InstructorLessonEditView(LessonCreateViewModel entry)
        {
            var model = new LessonCreateViewModel();
            model.Save(entry);

            return View(model);
        }



#endregion

        public ActionResult InstructorCourseManagementView()
        {
            return View();
        }
        public ActionResult InstructorCourseEditView()
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