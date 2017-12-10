using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityNew.Models
{
    public class HomeworkEditViewModel
    {
        private Context db = new Context();

        public HomeworkEditViewModel()
        {
            QuestionList = new List<string>();
            AnswerList = new List<string>();
            TFAnswerList = new List<bool>();
            MCAnswerList = new List<int>();
        }

        public WorkModel Work { get; set; }
        public QuestionsModel QuestionModel { get; set; }
        public AnswerModel AnswerModel { get; set; }
        public List<string> QuestionList { get; set; }
        public List<string> AnswerList { get; set; }
        public List<bool> TFAnswerList { get; set; }
        public List<int> MCAnswerList { get; set; }

        /// <summary>
        /// Load a work, questions, and answers from a work ID
        /// </summary>
        /// <param name="workID"></param>
        /// <returns>HomeworkCreateViewModel</returns>
        public HomeworkEditViewModel Load (int workID)
        {
            var model = new HomeworkEditViewModel();

            model.Work = db.WorkModels.FirstOrDefault(f => f.ID == workID);
            // load the questions modelq
            model.QuestionModel = db.QuestionModels.FirstOrDefault(f => f.ID == model.Work.QuestionsID);
            if (model.QuestionModel.ID > 0)
            {   // load the questions
                model.QuestionModel.Questions = db.StringQuestions.Where(q => q.QuestionModelID == model.Work.QuestionsID).ToList();
            }
            //load the answer model
            model.AnswerModel = db.AnswerModels.FirstOrDefault(f => f.ID == model.Work.AnswerID);
            if (model.AnswerModel.ID > 0)
            {   // load the answers
                model.AnswerModel.Answers = db.StringAnswers.Where(q => q.AnswerModelID == model.Work.AnswerID).ToList();
            }

            // get the correct answers
            if (model.AnswerModel.TrueFalse)
            {
                foreach (var answer in model.AnswerModel.Answers)
                {
                    if (answer.Answer == "True" || answer.Answer == "True") { model.TFAnswerList.Add(true); }
                    else { model.TFAnswerList.Add(false); }
                }
            }
            else if (model.AnswerModel.StringMatching)
            {
                foreach (var answer in model.AnswerModel.Answers)
                {
                    model.AnswerList.Add(answer.Answer);
                }
            }
            else if (model.AnswerModel.MultipleChoice)
            {
                foreach (var answer in model.AnswerModel.Answers)
                {
                    model.MCAnswerList.Add(Convert.ToInt32(answer.Answer));
                }
            }
            else if (model.AnswerModel.GradeByHand)
            {
                foreach (var answer in model.AnswerModel.Answers)
                {
                    model.AnswerList.Add(answer.Answer);
                }
            }


            return model;
        }

        /// <summary>
        /// Saves the work, questions, and answers from an HCVM object
        /// </summary>
        /// <param name="obj"></param>
        public void Save(HomeworkEditViewModel obj)
        {

            // save work
            if (obj.Work.ID > 0)
            {
                db.Entry(obj.Work).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
#warning TODO: need to check to make sure that all variables are loaded into Work before saving
                db.WorkModels.Add(obj.Work);
                db.SaveChanges();
            }
            // save questions
            //if (questions.ID > 0)
            //{
            //    db.Entry(questions).State = EntityState.Modified;
            //    db.SaveChanges();
            //}
            //else
            //{
            //    db.QuestionModels.Add(questions);
            //    db.SaveChanges();
            //}
            ////save answers
            //if (answer.ID > 0)
            //{
            //    db.Entry(answer).State = EntityState.Modified;
            //    db.SaveChanges();
            //}
            //else
            //{
            //    db.WorkModels.Add(work);
            //    db.SaveChanges();
            //}
        }

    }
}