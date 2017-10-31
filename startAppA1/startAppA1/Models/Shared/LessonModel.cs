using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace startAppA1.Models
{
    public class LessonModel
    {
        public LessonModel()
        {
            NextLessonIDs = new List<int>();
            PreviousLessonIDs = new List<int>();
        }

        [Key]
        [Required]
        public int ID { get; set; }
        public string Title { get; set; }
        public string IntroText { get; set; }
        public int TemplateID { get; set; } // needs models
        public int DataID { get; set; } // stringified html?
        public WorkModel WorkItem { get; set; }
        public List<int> NextLessonIDs { get; set; }
        public List<int> PreviousLessonIDs { get; set; }
        public DateTime OpenAtTime { get; set; }
        public DateTime CloseAtTime { get; set; }
        public DateTime TimeLimit { get; set; }
        public bool HasVideo { get; set; }
        public string VideoHtml { get; set; } // check htmlstring objects & see if easier

        //foriegn keys for relationships
        public int? CourseID { get; set; }
        public CourseModel Course { get; set; }
        public int? StudentID { get; set; }
        public StudentModel Student { get; set; }
    }
}