using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace startAppA1.Models
{
    public class LessonModel
    {
        public LessonModel()
        {
            //NextLessonIDs = new List<int>();
            //PreviousLessonIDs = new List<int>();
        }

        [Key]
        [Required]
        public int ID { get; set; }
        public string Title { get; set; }
        public string IntroText { get; set; }
        public int TemplateID { get; set; }
        
        public int NextLessonIDs { get; set; }
        public int PreviousLessonIDs { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime OpenAtTime { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime CloseAtTime { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime TimeLimit { get; set; }
        public bool HasVideo { get; set; }
        public string VideoHtml { get; set; } // check htmlstring objects & see if easier?

        //foriegn keys for relationships
        public int? CourseID { get; set; }
        public CourseModel Course { get; set; }
        public int? StudentID { get; set; }
        public StudentModel Student { get; set; }
        public int? LessonDataID { get; set; }
        public LessonDataModel LessonData { get; set; }
        public int? WorkID { get; set; }
        public WorkModel WorkItem { get; set; }
    }
}