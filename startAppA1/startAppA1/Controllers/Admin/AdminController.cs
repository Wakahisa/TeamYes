using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using startAppA1.Models;
using System.Web.Mvc;

namespace startAppA1.Controllers.Admin
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

        /// <summary>
        /// Initates editing of the selected student record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditStudent(int? id)
        {
            var model = new StudentModel();
            if (id != null)
            {
                model = db.StudentModels.Find(id);
            }
            return PartialView("_StudentEditView", model);
        }

        /// <summary>
        /// Save function for the student record
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditStudent(StudentModel model)
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
            return PartialView("AdminView");
        }





    }
}