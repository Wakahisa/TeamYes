using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace startAppA1.Models
{
    public class CourseModel
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public List<LessonModel> Lessons { get; set; }
        public List<WorkModel> Homeworks { get; set; }
        public List<int> LessonOrderByID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<StudentModel> Students { get; set; }
    }
}