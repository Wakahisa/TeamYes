using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace startAppA1.Models
{
    public class HomeworkCreateViewModel
    {
        private Context db = new Context();

        public HomeworkCreateViewModel()
        {
        }

        public WorkModel work { get; set; }
        public QuestionstModel questions { get; set; }
        public AnswerModel answer { get; set; }
        

        /// <summary>
        /// Create empty work & view for editing
        /// </summary>
        /// <returns>HomeworkCreateViewModel</returns>
        public HomeworkCreateViewModel Load()
        {
            var model = new HomeworkCreateViewModel();
            model.work = new WorkModel();
            model.questions = new QuestionstModel();
            model.answer = new AnswerModel();

            model.work.Title = "Empty Title";
            model.work.IsProgramming = false;
            model.work.InstructorNotes = "Note text";
            model.work.InstructionText = "Instructions go here";

            return model;
        }

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