using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace startAppA1.Models
{
    public class WorkModel
    {
        public WorkModel() { }

        [Key]
        [Required]
        public int ID { get; set; }
        public string InstructionText { get; set; }
        public int TemplateID { get; set; }
        public int WorkSetID { get; set; }
        public int LessonID { get; set; }
        public int AnswerID { get; set; }
        public double Grade { get; set; }
        public string InstructorNotes { get; set; }
        public bool Passed { get; set; }
        public bool IsProgramming { get; set; }

        //foriegn keys for relationships
        public int? CourseID { get; set; }
        public CourseModel Course { get; set; }
        public int? StudentID { get; set; }
        public StudentModel Student { get; set; }

    }
}