using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace startAppA1.Models
{
    public class GradeModel
    {
        public GradeModel()
        {
            GradeNumbers = new List<double>();
        }

        [Key]
        [Required]
        public int ID { get; set; }
        public List<double> GradeNumbers { get; set; }
        public double CurrentTotalGrade { get; set; }

        //foriegn keys for relationships
        public int? StudentID { get; set; }
        public StudentModel Student { get; set; }
    }
}