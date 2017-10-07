using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace startAppA1.Models.Student
{
    public class Student
    {
        /// Identifiers for a student
        [Key]
        [Column(Order =2)]
        [Display(Name = "Student ID")]
        public int Student_ID { get; set; }

        [Required]
        [Display(Name = "Student First Name")]
        public String Stud_F_Name { get; set; }

        [Required]
        [Display(Name = "Student Last Name")]
        public String Stud_L_Name { get; set; }
    }
}