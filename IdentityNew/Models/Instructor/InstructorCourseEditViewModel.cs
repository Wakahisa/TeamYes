using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityNew.Models
{
    public class InstructorCourseEditViewModel
    {
        private Context db = new Context();

        public InstructorCourseEditViewModel()
        {
            CurrentLessons = new List<LessonModel>();
        }

        public IEnumerable<SelectListItem> LessonList { get; set; }
        public IEnumerable<SelectListItem> LessonOrder { get; set; }
        public CourseModel Course { get; set; }
        public List<LessonModel> CurrentLessons { get; set; }

        public void Load(int courseID)
        {
            Course = db.CourseModels.FirstOrDefault(x => x.ID == courseID);

            // load teh current course lessons into the display list
            CurrentLessons = db.LessonModels.Where(x => x.CourseID == courseID).ToList();
            LessonList = CurrentLessons.Select(x =>
                    new SelectListItem { Text = x.Title, Value = x.ID.ToString()}).ToList();

#warning set this to grab only lessons belonging to courses and not lessons belonging to students at some point
            //because take a while ot write and debug getting correct lessons
            LessonOrder = db.LessonModels.Select(x =>
                                new SelectListItem { Text = x.Title, Value = x.ID.ToString() }).ToList(); ;
        }

        public void Set(InstructorCourseEditViewModel model)
        {
#warning need to write contents for setting data into DB
        }

    }
}