using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;


namespace startAppA1.Models
{
    public class StudentModel
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInital { get; set; }
        public List<CourseModel> Courses { get; set; }
        public List<LessonModel> InProgressLessons { get; set; }
        public List<WorkModel> Homeworks { get; set; }
        public MailAddress EmailAddress { get; set; }
        public List<GradeModel> CourseGrade { get; set; }

    }
}