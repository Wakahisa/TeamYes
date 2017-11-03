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
        public ActionResult InstructorLessonEditView()
        {
            var model = new LessonCreateViewModel();
            model.Load(db.LessonModels.FirstOrDefault());
            return View(model);
        }

        /// <summary>
        /// loads a lesson into the view by passing in the lessonID
        /// </summary>
        /// <param name="lessonID"></param>
        /// <returns></returns>
        public ActionResult LoadLessonForEdit(int? lessonID)
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

        /// <summary>
        /// loads an empty lesson to be edited
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateNewLesson()
        {
            var model = new LessonCreateViewModel();
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