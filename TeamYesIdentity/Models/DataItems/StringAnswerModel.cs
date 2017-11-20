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
            AnswerModels = new List<AnswerModel>();
        }
        public StringAnswerModel()
        {
            AnswerModels = new List<AnswerModel>();
        }

        [Key]
        [Required]
        public int ID { get; set; }
        public string Answer { get; set; }

        public int? AnswerModelID { get; set; }
        public ICollection<AnswerModel> AnswerModels { get; set; }

    }
}