﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityNew.Models
{
    public class AnswerModel
    {
        public AnswerModel()
        {
            Answers = new List<StringAnswerModel>();
            AnswerIDs = new List<int>();
        }

        [Key]
        [Required]
        public int ID { get; set; }
        public string Title { get; set; }
        public bool TrueFalse { get; set; }
        public bool MultipleChoice { get; set; }
        public bool StringMatching { get; set; }
        public bool GradeByHand { get; set; }
        public List<bool> TrueFalseAnswers { get; set; }
        public List<int> MultiChoiceAnswers { get; set; }
        public List<string> StringMatchAnswers { get; set; }
        public List<string> ByHandAnswers { get; set; } // just in case
        public ICollection<int> AnswerIDs { get; set; }
        public ICollection<StringAnswerModel> Answers { get; set; }
        
    }
}