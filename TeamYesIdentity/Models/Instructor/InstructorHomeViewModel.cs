using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamYesIdentity.Models
{
    public class InstructorHomeViewModel
    {
        private Context db = new Context();

        public InstructorHomeViewModel()
        {
            CourseList = new List<CourseModel>();
            StudentList = new List<StudentModel>();
        }

        public List<CourseModel> CourseList { get; set; }
        public List<StudentModel> StudentList { get; set; }

        /// <summary>
        /// Loads db tables into obj
        /// </summary>
        /// <param name="instructorID"></param>
        public void Load(int instructorID)
        {
            CourseList = db.CourseModels.Where(f=>f.InstructorID == instructorID).ToList();

            // not the best code, and it doesn't work
            //foreach (CourseModel course in CourseList)
            //{
            //    var tempList = db.StudentModels.Where(f => f.CourseIDs.Contains(course.ID)).ToList();
            //    StudentList.AddRange(tempList);
            //}
            StudentList = db.StudentModels.ToList();

        }


    }
}