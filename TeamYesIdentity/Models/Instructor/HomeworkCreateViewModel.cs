using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TeamYesIdentity.Models
{
    public class HomeworkCreateViewModel
    {
        private Context db = new Context();

        public HomeworkCreateViewModel()
        {
            questionList = new List<string>();
            answerList = new List<string>();
            TFAnswerList = new List<bool>();
            MCAnswerList = new List<int>();
        }

        public WorkModel work { get; set; }
        public QuestionsModel questions { get; set; }
        public AnswerModel answer { get; set; }
        public List<string> questionList { get; set; }
        public List<string> answerList { get; set; }
        public List<bool> TFAnswerList { get; set; }
        public List<int> MCAnswerList { get; set; }

        /// <summary>
        /// Load a work, questions, and answers from a work ID
        /// </summary>
        /// <param name="workID"></param>
        /// <returns>HomeworkCreateViewModel</returns>
        public HomeworkCreateViewModel Load (int workID)
        {
            var model = new HomeworkCreateViewModel();

            model.work = db.WorkModels.FirstOrDefault(f => f.ID == workID);
            model.questions = db.QuestionModels.FirstOrDefault(f => f.ID == work.QuestionsID);
            model.answer = db.AnswerModels.FirstOrDefault(f => f.ID == work.AnswerID);
            model.questionList = model.questions.Questions;
            if (model.answer.TrueFalse)
            {
                model.TFAnswerList = model.answer.TrueFalseAnswers;
            }
            else if (model.answer.MultipleChoice)
            {
                model.MCAnswerList = model.answer.MultiChoiceAnswers;
            }
            else if (model.answer.StringMatching)
            {
                model.answerList = model.answer.StringMatchAnswers;
            }

            return model;
        }

        /// <summary>
        /// Saves the work, questions, and answers from an HCVM object
        /// </summary>
        /// <param name="obj"></param>
        public void Save(HomeworkCreateViewModel obj)
        {

            // save work
            if (work.ID > 0)
            {
                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.WorkModels.Add(work);
                db.SaveChanges();
            }
            // save questions
            if (questions.ID > 0)
            {
                db.Entry(questions).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.QuestionModels.Add(questions);
                db.SaveChanges();
            }
            //save answers
            if (answer.ID > 0)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.WorkModels.Add(work);
                db.SaveChanges();
            }
        }

    }
}