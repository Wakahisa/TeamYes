using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TeamYesIdentity.Models
{
    public class WorkModel
    {
        public WorkModel()
        {
            Students = new List<StudentModel>();
    }

        [Key]
        [Required]
        public int ID { get; set; }
        public int? TemplateID { get; set; }

        public string Title { get; set; }
        public string InstructionText { get; set; }
        public double Grade { get; set; }
        public string InstructorNotes { get; set; }
        public bool Passed { get; set; }
        public bool IsProgramming { get; set; }

        //foriegn keys for relationships
        public int? QuestionsID { get; set; }
        public QuestionsModel Questions { get; set; }
        public int? AnswerID { get; set; }
        public AnswerModel Answers { get; set; }
        public ICollection<StudentModel> Students { get; set; }

    }
}