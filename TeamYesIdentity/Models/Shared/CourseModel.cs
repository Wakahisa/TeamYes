using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TeamYesIdentity.Models
{
    public class CourseModel
    {
        public CourseModel()
        {
            Lessons = new List<LessonModel>();
            Homeworks = new List<WorkModel>();
            Students = new List<StudentModel>();
            LessonOrderByID = new List<int>();
        }

        [Key]
        [Required]
        public int ID { get; set; }

        public List<int> LessonOrderByID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //foriegn keys for relationships
        public int? InstructorID { get; set; }
        public InstructorModel Instructor { get; set; }
        public virtual ICollection<int> StudentIDs { get; set; }
        public virtual ICollection<StudentModel> Students { get; set; }
        public virtual ICollection<int> LessonIDs { get; set; }
        public virtual ICollection<LessonModel> Lessons { get; set; }
        public virtual ICollection<int> HomeworkIDs { get; set; }
        public virtual ICollection<WorkModel> Homeworks { get; set; }
    }
}