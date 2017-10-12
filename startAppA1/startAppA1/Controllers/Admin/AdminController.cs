using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using startAppA1.Models;
using System.Web.Mvc;

namespace startAppA1.Controllers.Admin
{
    public class AdminController : Controller
    {
        private Context db = new Context();
        // GET: Admin
        public ActionResult AdminView()
        {
            return View();
        }

        public ActionResult LoadStudents()
        {
            var model = db.StudentModels.ToList();
            return PartialView("_StudentTableView", model);
        }
        public ActionResult LoadInstructors()
        {
            var model = db.InstructorModels.ToList();
            return PartialView("_InstructorTableView", model);
        }




    }
}