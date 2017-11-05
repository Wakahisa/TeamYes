namespace startAppA1.Migrations
{
    using startAppA1.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<startAppA1.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(startAppA1.Models.Context context)
        {
            /// <summary>
            /// Clean the db before re-seeding
            /// Do this for every table that you create a seed method for
            /// </summary>
            context.AnswerModels.RemoveRange(context.AnswerModels);
            context.CourseModels.RemoveRange(context.CourseModels);
            context.InstructorModels.RemoveRange(context.InstructorModels);
            context.LessonDataModels.RemoveRange(context.LessonDataModels);
            context.LessonModels.RemoveRange(context.LessonModels);
            context.QuestionModels.RemoveRange(context.QuestionModels);
            context.StudentModels.RemoveRange(context.StudentModels);
            context.WorkModels.RemoveRange(context.WorkModels);

            /// <summary>
            /// Add models
            /// </summary>
            context.CourseModels.Add(new CourseModel
            {
                ID = 1,
                Title = "Into to Programming",
                Description = "In this course you will learn about programming.",
                //InstructorID = 2,
                LessonOrderByID = new List<int>(new int[]
                {
                    1,2,3
                }),
                StudentIDs = new List<int>(new int[]
                {
                    1,2
                })
            });
            context.LessonModels.Add(new LessonModel
            {
                ID = 1,
                CourseID = 1,
                HasVideo = true,
                IntroText = "Welcome to lesson one!",
                LessonDataID = 1,
                NextLessonIDs = 2,
                PreviousLessonIDs = -1,
                TemplateID = 1,
                Title = "Learning about code!",
                VideoHtml = "https://www.youtube.com/embed/pqmhZcPpTys?rel=0",
                WorkID = 1,
            });
            context.LessonModels.Add(new LessonModel
            {
                ID = 2,
                CourseID = 1,
                HasVideo = true,
                IntroText = "Welcome to lesson two!",
                LessonDataID = 2,
                NextLessonIDs = 3,
                PreviousLessonIDs = 1,
                TemplateID = 1,
                Title = "Learning some basics!",
                VideoHtml = "https://www.youtube.com/embed/pqmhZcPpTys?rel=0",
                WorkID = 2,
            });
            context.LessonModels.Add(new LessonModel
            {
                ID = 3,
                CourseID = 1,
                HasVideo = true,
                IntroText = "Welcome to the last lesson!",
                LessonDataID = 1,
                NextLessonIDs = 2,
                PreviousLessonIDs = -1,
                TemplateID = 1,
                Title = "Learning about being a programmer!",
                VideoHtml = "https://www.youtube.com/embed/pqmhZcPpTys?rel=0",
                WorkID = 3,
            });
            context.LessonDataModels.Add(new LessonDataModel
            {
                ID = 1,
                Placeholder = "In lesson one we learn about types of variables, if and switch statements, and the difference between public and private variables. Please watch the video."

            });
            context.LessonDataModels.Add(new LessonDataModel
            {
                ID = 2,
                Placeholder = "In lesson two we learn what a class is, about bits and bytes, and the history of pointers. Please watch the video."

            });
            context.LessonDataModels.Add(new LessonDataModel
            {
                ID = 3,
                Placeholder = "In lesson three we learn about the python programming language, lists, and how to declare a class. Please watch the video."

            });
            context.QuestionModels.Add(new QuestionstModel
            {
                ID = 1,
                Title = "L1TrueFalseQs",
                Questions = new List<string>(new string[] {
                    "You use a double type of variable to hold decimal numbers.",
                    "You cannot duplicate the effects of nested if/then/else with a switch statement.",
                    "A private class variable can be called by functions in a different class."
                })
            });
            context.QuestionModels.Add(new QuestionstModel
            {
                ID = 2,
                Title = "L2MultipleChoiceQs",
                Questions = new List<string>(new string[] {
                    "A class is:   1. A file   2. An object   3. Both   4. Neither   5. More complicated than that",
                    "How many bits are in a byte?   1. Two bits   2. Four bits   3. Six bits   4. Eight bits",
                    "Pointers are:  1. God's gift to programmers.   2. A horror that programming languages have outgrown.   3. I like lasers!   4. What's a pointer?"
                })
            });
            context.QuestionModels.Add(new QuestionstModel
            {
                ID = 3,
                Title = "L3StringMatchQs",
                Questions = new List<string>(new string[] {
                    "What programming language does this class teach?",
                    "What number does the index of a list start at?",
                    "Rewrite the following line of code correctly: public void FindAndReturnIdNumberOfPersonByName (long nameVariable)"
                })
            });
            context.AnswerModels.Add(new AnswerModel
            {
                ID = 1,
                Title = "L1TrueFalseAnswers",
                GradeByHand = false,
                MultipleChoice = false,
                StringMatching = false,
                TrueFalse = true,
                TrueFalseAnswers = new List<bool>(new bool[]
                {
                    true,true,false
                })
            });
            context.AnswerModels.Add(new AnswerModel
            {
                ID = 2,
                Title = "L2MultipleChoiceAnswers",
                GradeByHand = false,
                MultipleChoice = true,
                StringMatching = false,
                TrueFalse = false,
                MultiChoiceAnswers = new List<int>(new int[]
                {
                    5,4,3
                })
            });
            context.AnswerModels.Add(new AnswerModel
            {
                ID = 3,
                Title = "L3StringMatchAnswers",
                GradeByHand = false,
                MultipleChoice = false,
                StringMatching = true,
                TrueFalse = false,
                StringMatchAnswers = new List<string>(new string[]
               {
                    "python","0","public int FindAndReturnIdNumberOfPersonByName (string nameVariable)"
               })
            });
            context.StudentModels.Add(new StudentModel
            {
                ID = 1,
                StudentID = 100,
                FirstName = "Amy",
                LastName = "Addams",
                MiddleInital = "A",
                EmailAddress = "A@uaa.edu"
            });
            context.StudentModels.Add(new StudentModel
            {
                ID = 2,
                StudentID = 101,
                FirstName = "Bob",
                LastName = "Badger",
                MiddleInital = "B",
                EmailAddress = "B@uaa.edu"
            });
            context.InstructorModels.Add(new InstructorModel
            {
                ID = 1,
                IsAdmin = true,
                FirstName = "Carl",
                LastName = "Carpenter",
                MiddleInital = "C",
            });
            context.InstructorModels.Add(new InstructorModel
            {
                ID = 2,
                IsAdmin = false,
                FirstName = "Donna",
                LastName = "Dorisdotter",
                MiddleInital = "D",
            });
            context.WorkModels.Add(new WorkModel
            {
                ID = 1,
                Title = "True and False Lesson 1",
                AnswerID = 1,
                QuestionsID = 1,
                IsProgramming = false,
                InstructionText = "Answer these three true/false quesions.",
            });
            context.WorkModels.Add(new WorkModel
            {
                ID = 2,
                Title = "Multiple Choice Lesson 2",
                AnswerID = 2,
                QuestionsID = 2,
                IsProgramming = false,
                InstructionText = "Answer these multiple choice quesions by typing in the number.",
            });
            context.WorkModels.Add(new WorkModel
            {
                ID = 3,
                Title = "String Match Lesson 3",
                AnswerID = 3,
                QuestionsID = 3,
                IsProgramming = false,
                InstructionText = "Answer these three quesions.",
            });

        }
    }
}
