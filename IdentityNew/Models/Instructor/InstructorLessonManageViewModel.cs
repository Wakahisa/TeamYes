using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityNew.Models
{
    public class InstructorLessonManageViewModel
    {
        private Context db = new Context();

        public InstructorLessonManageViewModel()
        {
            StudentWorks = new List<WorkModel>();
            StudentGrades = new List<string>();
            StudentList = new List<StudentModel>();
        }

        public LessonModel CurrentLesson { get; set; }
        public List<StudentModel> StudentList { get; set; }
        public LessonDataModel LessonData { get; set; }
        public List<WorkModel> StudentWorks { get; set; }
        public WorkModel CurrentWork { get; set; }

        public string LessonDataDisplayString { get; set; }
        public List<string> StudentGrades { get; set; }

        /// <summary>
        /// Load up the model from the database
        /// </summary>
        /// <param name="lessonID"></param>
        public void Load(int lessonID)
        {
            CurrentLesson = db.LessonModels.FirstOrDefault(f => f.ID == lessonID);

#warning Needs fixing: grab only students with this lesson in progress
            //StudentList = db.StudentModels.Where(f => f.InProgressLessons.Contains(CurrentLesson)).ToList();
            StudentList = db.StudentModels.ToList(); // fix this sometime, currently gets all students in db

            LessonData = db.LessonDataModels.FirstOrDefault(f => f.ID == CurrentLesson.LessonDataID);
            LessonDataDisplayString = LessonData.Placeholder.ToString();
            CurrentWork = db.WorkModels.FirstOrDefault(f => f.ID == CurrentLesson.WorkID);

            // not working, load each work form each student into the student
            //foreach (var student in StudentList)
            //{
            //    StudentWorks.Add(student.Homeworks.FirstOrDefault(f=>f.Title==CurrentWork.Title));
            //}
            // note to self: studentWorks and studentList are in the same order as of this point
            StudentWorks.Add(db.WorkModels.FirstOrDefault(x => x.ID == 4));
            StudentWorks.Add(db.WorkModels.FirstOrDefault(x => x.ID == 6));
            StudentGrades.Add("100");
            StudentGrades.Add("33.3");
        }

    }
}