using TeamYesIdentity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.IO;

namespace TeamYesIdentity.Controllers.Instructor
{

    public class InstructorController : Controller
    {
        private Context db = new Context();

        /// <summary>
        /// load list of courses and students for the instructor
        /// </summary>
        /// <returns></returns>
        public ActionResult InstructorHomeView()
        {
            var model = new InstructorHomeViewModel();

            // replace with model.Load( PASSED IN USER ID );
            model.Load(2);

            return View(model);
        }

        public ActionResult InstructorCourseCreationView()
        {
            return View();
        }

#region Lesson Edit

        /// <summary>
        /// Loads a lesson for editing via the model load method
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

        /// <summary>
        /// savefile method
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveFile()
        {
            try
            {
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var pic = System.Web.HttpContext.Current.Request.Files["SavedFiles"];
                    HttpPostedFileBase filebase = new HttpPostedFileWrapper(pic);
                    var fileName = Path.GetFileName(filebase.FileName);
                    var path = Path.Combine(Server.MapPath("~/UploadFile/"), fileName);
                    filebase.SaveAs(path);
                    return Json("File Saved Successfully.");
                }
                else { return Json("No File Saved."); }
            }
            catch (Exception ex) { return Json("Error While Saving."); }
        }

        /// <summary>
        /// Saves the lesson via the model save method
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InstructorLessonEditView(LessonCreateViewModel entry)
        {
            var model = new LessonCreateViewModel();
            model.Save(entry);

            return View(model);
        }

        #endregion

#region Work Edit

        /// <summary>
        /// Loads a homework set into the homework view for editing via the model load method
        /// </summary>
        /// <param name="workID"></param>
        /// <returns></returns>
        public ActionResult InstructorWorkEditView(int? workID)
        {
            var model = new HomeworkEditViewModel();
            if (workID > 0)
            {
                model = model.Load((int)workID);
            }
            else
            {
                model.Work = new WorkModel();
                model.QuestionModel = new QuestionsModel();
                model.AnswerModel = new AnswerModel();

                model.Work.Title = "Empty Title";
                model.Work.IsProgramming = false;
                model.Work.InstructorNotes = "Note text";
                model.Work.InstructionText = "Instructions go here";

                model.AnswerList.Capacity = 20;
                model.QuestionList.Capacity = 20;
                model.TFAnswerList.Capacity = 20;
                model.MCAnswerList.Capacity = 20;
            }
            return View(model);
        }

        /// <summary>
        /// Saves the work, questions, and answers via the model save method
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InstructorWorkEditView(HomeworkEditViewModel entry)
        {
            var model = new HomeworkEditViewModel();
            model.Save(entry);

            return View(model);
        }

#endregion

        /// <summary>
        /// Loads a course for the instructor to work in
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public ActionResult InstructorCourseManagementView(int courseID)
        {
            //var model = db.CourseModels.FirstOrDefault(f => f.ID == courseID);
            var model = new InstructorCourseManageViewModel();
            model.Load(courseID);
            return View(model);
        }


        public ActionResult InstructorCourseEditView()
        {
            return View();
        }

        /// <summary>
        /// loads a lesson, it's students, and work for display
        /// </summary>
        /// <param name="lessonID"></param>
        /// <returns></returns>
        public ActionResult InstructorLessonManagementView(int? lessonID)
        {
            var model = new InstructorLessonManageViewModel();
            if (lessonID > 0)
            {
                model.Load((int)lessonID);
            }
            else
            {
                model.Load(1);
            }          
            return View(model);
        }

        public ActionResult InstructorStudentManagementView()
        {
            return View();
        }
    }
}