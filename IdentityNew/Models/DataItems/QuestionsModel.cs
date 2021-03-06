﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityNew.Models
{
    public class QuestionsModel
    {
        public QuestionsModel()
        {
            QuestionIDs = new List<int>();
            Questions = new List<StringQuestionModel>();
        }

        [Key]
        [Required]
        public int ID { get; set; }
        public string Title { get; set; }
        public ICollection<int> QuestionIDs { get; set; }
        public ICollection<StringQuestionModel> Questions { get; set; }
        
    }
}