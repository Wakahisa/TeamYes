using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamYesIdentity.Models
{
    public class LessonDataModel
    {
        public LessonDataModel()
        {

        }

        [Key]
        [Required]
        public int ID { get; set; }
        public string Placeholder { get; set; }
    }
}