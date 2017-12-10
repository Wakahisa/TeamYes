using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;


namespace IdentityNew.Models
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

        public ICollection<int> CourseIDs { get; set; }
        public ICollection<CourseModel> Courses { get; set; }
        public ICollection<int> LessonIDs { get; set; }
        public ICollection<LessonModel> InProgressLessons { get; set; }
        public ICollection<int> WorkIDs { get; set; }
        public ICollection<WorkModel> Homeworks { get; set; }
        public ICollection<int> GradeIDs { get; set; }
        public ICollection<GradeModel> CourseGrade { get; set; }

    }
}