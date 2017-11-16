using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;


namespace TeamYesIdentity.Models
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
        public string EmailAddress { get; set; }

        public string LoginName { get; set; }
        public string Password { get; set; }
        public string PasswordShield { get; set; }
        
        //foriegn keys for relationships

        public List<int> CourseIDs { get; set; }
        public List<CourseModel> Courses { get; set; }
        public List<int> LessonIDs { get; set; }
        public List<LessonModel> InProgressLessons { get; set; }
        public List<int> WorkIDs { get; set; }
        public List<WorkModel> Homeworks { get; set; }
        public List<int> GradeIDs { get; set; }
        public List<GradeModel> CourseGrade { get; set; }

    }
}