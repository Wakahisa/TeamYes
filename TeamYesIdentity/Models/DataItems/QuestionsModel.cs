using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamYesIdentity.Models
{
    public class QuestionstModel
    {
        public QuestionstModel()
        {
            Questions = new List<string>();
        }

        [Key]
        [Required]
        public int ID { get; set; }
        public string Title { get; set; }
        public List<string> Questions { get; set; }

    }
}