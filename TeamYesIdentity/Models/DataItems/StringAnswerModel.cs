using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamYesIdentity.Models
{
    public class StringAnswerModel
    {
        public StringAnswerModel(string ans)
        {
            Answer = ans;
        }

        [Key]
        [Required]
        public int ID { get; set; }
        public string Answer { get; set; }

        public int? AnswerModelID { get; set; }
        public AnswerModel AnswerModel { get; set; }
    }
}