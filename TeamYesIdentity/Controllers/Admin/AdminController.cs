using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TeamYesIdentity.Models;
using System.Web.Mvc;

namespace TeamYesIdentity.Controllers.Admin
{
    public class AdminController : Controller
    {
        private Context db = new Context();
        
        public ActionResult AdminView()
        {
            return View();
        }
        /// <summary>
        /// Loads student records into partial view list
        /// </summary>
        /// <returns></returns>
        public ActionResult LoadStudents()
        {
            var model = db.StudentModels.ToList();
            return PartialView("_StudentTableView", model);
        }

        /// <summary>
        /// Loads instructor records into partial view list
        /// </summary>
        /// <returns></returns>
        public ActionResult LoadInstructors()
        {
            var model = db.InstructorModels.ToList();
            return PartialView("_InstructorTableView", model);
        }

        public ActionResult LoadWorks()
        {
            var model = db.WorkModels.ToList();
            return PartialView("_WorkTableView", model);
        }

#region Student
        /// <summary>
        /// Initates editing of the selected student record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult StudentEditView(int? id)
        {
            var model = new StudentModel();
            if (id != null)
            {
                model = db.StudentModels.Find(id);
                model.PasswordShield="*************";
            }
            return View(model);
        }

        /// <summary>
        /// Save function for the student record
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StudentEditView(StudentModel model)
        {
            //var model = new StudentModel();
            if (ModelState.IsValid && model.ID > 0)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminView");
            }
            else if (ModelState.IsValid)
            {
                db.StudentModels.Add(model);
                db.SaveChanges();
                return RedirectToAction("AdminView");
            }
            return RedirectToAction("AdminView");
        }

        /// <summary>
        /// deletes a student from the db then returns to student list in admin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
         public ActionResult DeleteStudent(StudentModel model)
        {
            if(model != null)
            {
                db.StudentModels.Attach(model);
                db.StudentModels.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("AdminView");
        }
        #endregion

#region Instructor
        /// <summary>
        /// Initates editing of the selected Instructor record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult InstructorEditView(int? id)
        {
            var model = new InstructorModel();
            if (id != null)
            {
                model = db.InstructorModels.Find(id);
                model.PasswordShield = "*************";
            }
            return View(model);
        }

        /// <summary>
        /// Save function for the Instructor record
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InstructorEditView(InstructorModel model)
        {
            if (ModelState.IsValid && model.ID > 0)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LoadInstructors");
            }
            else if (ModelState.IsValid)
            {
                db.InstructorModels.Add(model);
                db.SaveChanges();
                return RedirectToAction("LoadInstructors");
            }
            return RedirectToAction("LoadInstructors");
        }

        /// <summary>
        /// deletes a Instructor from the db then returns to Instructor list in admin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DeleteInstructor(InstructorModel model)
        {
            if (model != null)
            {
                db.InstructorModels.Attach(model);
                db.InstructorModels.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("LoadInstructors");
        }
        #endregion

        #region Work
        /// <summary>
        /// Initates editing of the selected work record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult WorkEditView(int? id)
        {
            var model = new WorkModel();
            if (id != null)
            {
                model = db.WorkModels.Find(id);
            }
            return View(model);
        }

        /// <summary>
        /// Save function for the work record
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult WorkEditView(WorkModel model)
        {
            if (ModelState.IsValid && model.ID > 0)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LoadWorks");
            }
            else if (ModelState.IsValid)
            {
                db.WorkModels.Add(model);
                db.SaveChanges();
                return RedirectToAction("LoadWorks");
            }
            return RedirectToAction("LoadWorks");
        }

        /// <summary>
        /// deletes a Instructor from the db then returns to Instructor list in admin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DeleteWork(WorkModel model)
        {
            if (model != null)
            {
                db.WorkModels.Attach(model);
                db.WorkModels.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("LoadWorks");
        }
        #endregion

    }
}