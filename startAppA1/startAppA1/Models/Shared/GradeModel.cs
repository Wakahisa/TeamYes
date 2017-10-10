using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace startAppA1.Models
{
    public class GradeModel
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public List<double> GradeNumbers { get; set; }
        public double CurrentTotalGrade { get; set; }
    }
}