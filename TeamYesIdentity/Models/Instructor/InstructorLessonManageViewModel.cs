using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamYesIdentity.Models
{
    public class InstructorLessonManageViewModel
    {
        private Context db = new Context();

        public InstructorLessonManageViewModel()
        {
            StudentWorks = new List<WorkModel>();
            StudentList = new List<StudentModel>();
        }

        public LessonModel CurrentLesson { get; set; }
        public List<StudentModel> StudentList { get; set; }
        public LessonDataModel LessonData { get; set; }
        public List<WorkModel> StudentWorks { get; set; }
        public WorkModel CurrentWork { get; set; }
        
        /// <summary>
        /// Load up the model from the database
        /// </summary>
        /// <param name="lessonID"></param>
        public void Load(int lessonID)
        {
            CurrentLesson = db.LessonModels.FirstOrDefault(f => f.ID == lessonID);
            //StudentList = db.StudentModels.Where(f => f.InProgressLessons.Contains(CurrentLesson)).ToList();
            StudentList = db.StudentModels.ToList(); // fix this sometime
            LessonData = db.LessonDataModels.FirstOrDefault(f => f.ID == CurrentLesson.LessonDataID);
            CurrentWork = db.WorkModels.FirstOrDefault(f => f.ID == CurrentLesson.WorkID);
            //List<int> workingOn = new List<int>();
            foreach(var student in StudentList)
            {
                StudentWorks.Add(student.Homeworks.FirstOrDefault(f=>f.Title==CurrentWork.Title));
            }
            // note to self: studentWorks and studentList are in the same order as of this point
        }

    }
}