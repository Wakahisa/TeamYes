using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace startAppA1.Models
{
    public class LessonCreateViewModel
    {
        private Context db = new Context();

        public LessonCreateViewModel()
        {

        }
        public IEnumerable<SelectListItem> WorkList { get; set; }
        public int? WorkID { get; set; }
        public IEnumerable<SelectListItem> PreviousLessonList { get; set; }
        public int? PreviousID { get; set; }
        public IEnumerable<SelectListItem> NextLessonList { get; set; }
        public int? NextID { get; set; }

        public int LessonID { get; set; }
        public string Title { get; set; }
        public string Intro { get; set; }
        public string Text { get; set; }
        public string VideoLink { get; set; }

        /// <summary>
        /// Load up voew obj with an existing lesson
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>LessonCreateViewModel</returns>
        public LessonCreateViewModel Load(LessonModel obj)
        {
            var model = new LessonCreateViewModel();

            LessonID = obj.ID;
            Title = obj.Title;
            Intro = obj.IntroText;
            Text = db.LessonDataModels.FirstOrDefault(f => f.ID == obj.LessonDataID).Placeholder;
            if (obj.HasVideo)
            {
                VideoLink = obj.VideoHtml;
            }
            WorkList = db.WorkModels.Select(x => 
                    new SelectListItem { Text = x.Title, Value = x.ID.ToString() }).ToList();
            WorkID = obj.WorkID;
            PreviousLessonList = db.LessonModels.Select(x =>
                    new SelectListItem { Text = x.Title, Value = x.ID.ToString() }).ToList();
            PreviousID = obj.PreviousLessonIDs;
            NextLessonList = db.LessonModels.Select(x =>
                    new SelectListItem { Text = x.Title, Value = x.ID.ToString() }).ToList();
            NextID = obj.NextLessonIDs;

            return model;
        }

        /// <summary>
        /// Load up an empty view to be used
        /// </summary>
        /// <param></param>
        /// <returns>LessonCreateViewModel</returns>
        public LessonCreateViewModel Load()
        {
            var model = new LessonCreateViewModel();

            Title = "Insert Title Here";
            Intro = "Intro Text Goes Here";
            Text = "Lesson Text Goes Here";
            
            WorkList = db.WorkModels.Select(x =>
                    new SelectListItem { Text = x.InstructorNotes, Value = x.ID.ToString() }).ToList();
            PreviousLessonList = db.LessonModels.Select(x =>
                    new SelectListItem { Text = x.Title, Value = x.ID.ToString() }).ToList();
            NextLessonList = db.LessonModels.Select(x =>
                    new SelectListItem { Text = x.Title, Value = x.ID.ToString() }).ToList();

            return model;
        }

        /// <summary>
        /// Save editied lesson
        /// </summary>
        /// <param name="obj"></param>
        public void Save(LessonCreateViewModel obj)
        {
            var data = new LessonDataModel()
            {
                Placeholder = obj.Text
            };
            db.Entry(data).State = EntityState.Modified;
            // save the lesson data and get the primary key
            // awkward, but functional
            int dataID = db.LessonDataModels.FirstOrDefault(f => f.Placeholder == data.Placeholder).ID;

            bool hasVid = false;
            if (obj.VideoLink.Length > 0) { hasVid = true; }

            int lesID = db.LessonModels.FirstOrDefault(f => f.ID == obj.LessonID).ID;

            var model = new LessonModel()
            {
                Title = obj.Title,
                IntroText = obj.Intro,
                LessonDataID = dataID,
                HasVideo = hasVid,
                VideoHtml = obj.VideoLink ?? null,
                NextLessonIDs = obj.NextID ?? 0,
                PreviousLessonIDs = obj.PreviousID ?? 0,
                WorkID = obj.WorkID ?? 0,
            };
            if (lesID > 0) { model.ID = lesID; };
            // save the lesson

            if (model.ID > 0)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.LessonModels.Add(model);
                db.SaveChanges();
            }
        }


    }
}