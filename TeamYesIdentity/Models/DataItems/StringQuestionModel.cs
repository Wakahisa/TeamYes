using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamYesIdentity.Models
{
    public class StringQuestionModel
    {
        public StringQuestionModel(string que)
        {
            Question = que;
        }

        [Key]
        [Required]
        public int ID { get; set; }
        public string Question { get; set; }

        public int? QuestionModelID { get; set; }
        public QuestionsModel QuestionModel { get; set; }
    }
}