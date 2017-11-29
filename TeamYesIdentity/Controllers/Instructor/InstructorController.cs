using TeamYesIdentity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace TeamYesIdentity.Controllers.Instructor
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
            var model = new HomeworkCreateViewModel();
            if (workID > 0)
            {
                model.Load((int)workID);
            }
            else
            {
                model.work = new WorkModel();
                model.questions = new QuestionsModel();
                model.answer = new AnswerModel();

                model.work.Title = "Empty Title";
                model.work.IsProgramming = false;
                model.work.InstructorNotes = "Note text";
                model.work.InstructionText = "Instructions go here";

                model.answerList.Capacity = 20;
                model.questionList.Capacity = 20;
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
        public ActionResult InstructorWorkEditView(HomeworkCreateViewModel entry)
        {
            var model = new HomeworkCreateViewModel();
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