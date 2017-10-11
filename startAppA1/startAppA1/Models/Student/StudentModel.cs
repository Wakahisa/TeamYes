using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;


namespace startAppA1.Models
{
    public class StudentModel
    {
        public StudentModel()
        {
            Courses = new List<CourseModel>();
            InProgressLessons = new List<LessonModel>();
            Homeworks = new List<WorkModel>();
            CourseGrade = new List<GradeModel>();
        }

        [Key]
        [Required]
        public int ID { get; set; }

        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInital { get; set; }
        public virtual ICollection<CourseModel> Courses { get; set; }
        public virtual ICollection<LessonModel> InProgressLessons { get; set; }
        public virtual ICollection<WorkModel> Homeworks { get; set; }
        public string EmailAddress { get; set; }
        public virtual ICollection<GradeModel> CourseGrade { get; set; }
        
        //foriegn keys for relationships
        public int? CourseID { get; set; }
        public CourseModel Course { get; set; }

    }
}