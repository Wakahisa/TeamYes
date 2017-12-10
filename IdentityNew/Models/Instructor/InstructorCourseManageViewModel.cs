using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityNew.Models
{
    public class InstructorCourseManageViewModel
    {
        private Context db = new Context();

        public InstructorCourseManageViewModel()
        {
            LessonList = new List<LessonModel>();
            StudentList = new List<StudentModel>();
        }

        public List<LessonModel> LessonList { get; set; }
        public List<StudentModel> StudentList { get; set; }
        public CourseModel Course { get; set; }

        public void Load(int courseID)
        {
            Course = db.CourseModels.FirstOrDefault(f => f.ID == courseID);
            LessonList = db.LessonModels.Where(f => f.CourseID == courseID).ToList();

#warning Needs fixing: load all students with this course, not all students in db
            //StudentList = db.StudentModels.Where(f => f.CourseIDs.Contains(courseID)).ToList();
            //StudentList = db.StudentModels.Where(f => f.Courses.Contains(Course)).ToList();
            StudentList = Course.Students.ToList();
            if (StudentList.Count < 1)
            {
                StudentList = db.StudentModels.ToList();
            }
        }

    }
}