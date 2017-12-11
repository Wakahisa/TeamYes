using IdentityNew.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.IO;

namespace IdentityNew.Controllers.Instructor
{

    public class InstructorController : Controller
    {
        private Context db = new Context();

        /// <summary>
        /// load list of courses and students for the instructor
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult InstructorHomeView()
        {
            var model = new InstructorHomeViewModel();

            // replace with model.Load( PASSED IN USER ID );
            model.Load(2);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult InstructorCourseCreationView()
        {
            List<CourseModel> model = db.CourseModels.Where(x => x.ID > 0).ToList();
            return View();
        }

        #region Lesson Edit

        /// <summary>
        /// Loads a lesson for editing via the model load method
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
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

#warning TODO correct loading so that no student in progress or graded studd is included
            int counter = model.NextLessonList.Count();
            while (counter > 3)
            {
                model.NextLessonList.ElementAt(counter - 1).Disabled = true;
                counter--;
            }
            counter = model.NextLessonList.Count();
            while (counter > 3)
            {
                model.PreviousLessonList.ElementAt(counter - 1).Disabled = true;
                counter--;
            }
            counter = model.NextLessonList.Count();
            while (counter > 3)
            {
                model.WorkList.ElementAt(counter - 1).Disabled = true;
                counter--;
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult InstructorCourseManagementView(int courseID)
        {
            //var model = db.CourseModels.FirstOrDefault(f => f.ID == courseID);
            var model = new InstructorCourseManageViewModel();
            model.Load(courseID);
            return View(model);
        }


        /// <summary>
        /// loads up a current or empty course for editing
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public ActionResult InstructorCourseEditView(int? courseID)
        {
            var model = new InstructorCourseEditViewModel();
            if (courseID > 0)
            {
                model.Load((int)courseID);
            }

            return View(model);
        }

        /// <summary>
        /// loads a lesson, it's students, and work for display
        /// </summary>
        /// <param name="lessonID"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
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

        /// <summary>
        /// loads up a student for the view-a-student screen in instructor area
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult InstructorStudentManagementView(int? studentID)
        {
            var model = new StudentModel();
            if (studentID > 0)
            {
                model = db.StudentModels.FirstOrDefault(x => x.ID == (int)studentID);
#warning TODO: real loading, this is just for the demo
                if (model.ID == 1) // student 1 demo data
                {
                    model.Homeworks.Add(db.WorkModels.FirstOrDefault(x => x.ID == 4));
                    model.Homeworks.Add(db.WorkModels.FirstOrDefault(x => x.ID == 5));
                    model.InProgressLessons.Add(db.LessonModels.FirstOrDefault(x => x.ID == 5));
                    model.Courses.Add(db.CourseModels.FirstOrDefault(X => X.ID == 1));
                    model.Courses.Add(db.CourseModels.FirstOrDefault(X => X.ID == 2));
                }
                else // student 2 demo data
                {
                    model.Homeworks.Add(db.WorkModels.FirstOrDefault(x => x.ID == 6));
                    model.InProgressLessons.Add(db.LessonModels.FirstOrDefault(x => x.ID == 6));
                    model.Courses.Add(db.CourseModels.FirstOrDefault(X => X.ID == 1));
                }
            }
            return View(model);
        }
    }
}