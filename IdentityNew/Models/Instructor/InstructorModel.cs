﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityNew.Models
{
    public class InstructorModel
    {
        public InstructorModel()
        {
            Courses = new List<CourseModel>();
        }

        [Key]
        [Required]
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string MiddleInital { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<CourseModel> Courses { get; set; }
        public ICollection<int> CourseIDs { get; set; }
        public string EmailAddress { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string PasswordShield { get; set; }

    }
}