namespace TeamYesIdentity.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TeamYesIdentity.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TeamYesIdentity.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeamYesIdentity.Models.Context context)
        {
            /// <summary>
            /// Clean the db before re-seeding
            /// Do this for every table that you create a seed method for
            /// </summary>
            //context.AnswerModels.RemoveRange(context.AnswerModels);
            //context.CourseModels.RemoveRange(context.CourseModels);
            //context.InstructorModels.RemoveRange(context.InstructorModels);
            //context.LessonDataModels.RemoveRange(context.LessonDataModels);
            //context.LessonModels.RemoveRange(context.LessonModels);
            //context.QuestionModels.RemoveRange(context.QuestionModels);
            //context.StudentModels.RemoveRange(context.StudentModels);
            //context.WorkModels.RemoveRange(context.WorkModels);
            //context.StringAnswers.RemoveRange(context.StringAnswers);
            //context.StringQuestions.RemoveRange(context.StringQuestions);


            /// <summary>
            /// Add models
            /// </summary>
            context.LessonDataModels.AddOrUpdate(new LessonDataModel
            {
                ID = 1,
                Placeholder = "In lesson one we learn about types of variables, if and switch statements, and the difference between public and private variables. Please watch the video."

            });
            context.LessonDataModels.AddOrUpdate(new LessonDataModel
            {
                ID = 2,
                Placeholder = "In lesson two we learn what a class is, about bits and bytes, and the history of pointers. Please watch the video."

            });
            context.LessonDataModels.AddOrUpdate(new LessonDataModel
            {
                ID = 3,
                Placeholder = "In lesson three we learn about the python programming language, lists, and how to declare a class. Please watch the video."

            });
            context.QuestionModels.AddOrUpdate(new QuestionsModel
            {
                ID = 1,
                Title = "L1TrueFalseQs",
            });
            var questionSet = new List<StringQuestionModel>(new StringQuestionModel[] { new StringQuestionModel("You use a double type of variable to hold decimal numbers."),
                                                                            new StringQuestionModel("You cannot duplicate the effects of nested if/then/else with a switch statement."),
                                                                            new StringQuestionModel("A private class variable can be called by functions in a different class.")
                });
            var questionSetModel = context.QuestionModels.FirstOrDefault(c => c.ID == 1);
            questionSetModel.Questions = questionSet;
            context.QuestionModels.AddOrUpdate(questionSetModel);

            context.QuestionModels.AddOrUpdate(new QuestionsModel
            {
                ID = 2,
                Title = "L2MultipleChoiceQs",
                
            });
            questionSet = new List<StringQuestionModel>(new StringQuestionModel[] { new StringQuestionModel("A class is:   1. A file   2. An object   3. Both   4. Neither   5. More complicated than that"),
                                                                            new StringQuestionModel("How many bits are in a byte?   1. Two bits   2. Four bits   3. Six bits   4. Eight bits"),
                                                                            new StringQuestionModel("Pointers are:  1. God's gift to programmers.   2. A horror that programming languages have outgrown.   3. I like lasers!   4. What's a pointer?")
                });
            questionSetModel = context.QuestionModels.FirstOrDefault(c => c.ID == 2);
            questionSetModel.Questions = questionSet;
            context.QuestionModels.AddOrUpdate(questionSetModel);

            context.QuestionModels.AddOrUpdate(new QuestionsModel
            {
                ID = 3,
                Title = "L3StringMatchQs",
            });
            questionSet = new List<StringQuestionModel>(new StringQuestionModel[] { new StringQuestionModel("What programming language does this class teach?"),
                                                                            new StringQuestionModel("What number does the index of a list start at?"),
                                                                            new StringQuestionModel("Rewrite the following line of code correctly: public void FindAndReturnIdNumberOfPersonByName (long nameVariable)")
                });
            questionSetModel = context.QuestionModels.FirstOrDefault(c => c.ID == 3);
            questionSetModel.Questions = questionSet;
            context.QuestionModels.AddOrUpdate(questionSetModel);

            context.AnswerModels.AddOrUpdate(new AnswerModel
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
                }),
            });
            var answerSet = new List<StringAnswerModel>(new StringAnswerModel[]
                {
                    new StringAnswerModel("true"), new StringAnswerModel("true"), new StringAnswerModel("false")
                });
            var answerSetModel = context.AnswerModels.FirstOrDefault(c => c.ID == 1);
            answerSetModel.Answers = answerSet;
            context.AnswerModels.AddOrUpdate(answerSetModel);

            context.AnswerModels.AddOrUpdate(new AnswerModel
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
                }),
            });
            answerSet = new List<StringAnswerModel>(new StringAnswerModel[]
                {
                    new StringAnswerModel("5"), new StringAnswerModel("4"), new StringAnswerModel("3")
                });
            answerSetModel = context.AnswerModels.FirstOrDefault(c => c.ID == 2);
            answerSetModel.Answers = answerSet;
            context.AnswerModels.AddOrUpdate(answerSetModel);

            context.AnswerModels.AddOrUpdate(new AnswerModel
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
                }),
            });
            answerSet = new List<StringAnswerModel>(new StringAnswerModel[]
                {
                    new StringAnswerModel("python"), new StringAnswerModel("0"), new StringAnswerModel("public int FindAndReturnIdNumberOfPersonByName (string nameVariable)"),
                });
            answerSetModel = context.AnswerModels.FirstOrDefault(c => c.ID == 3);
            answerSetModel.Answers = answerSet;
            context.AnswerModels.AddOrUpdate(answerSetModel);

            context.StudentModels.AddOrUpdate(new StudentModel
            {
                ID = 1,
                StudentID = 100,
                FirstName = "Amy",
                LastName = "Addams",
                MiddleInital = "A",
                EmailAddress = "A@uaa.edu",                
            });
            context.StudentModels.AddOrUpdate(new StudentModel
            {
                ID = 2,
                StudentID = 101,
                FirstName = "Bob",
                LastName = "Badger",
                MiddleInital = "B",
                EmailAddress = "B@uaa.edu"
            });
            context.InstructorModels.AddOrUpdate(new InstructorModel
            {
                ID = 1,
                IsAdmin = true,
                FirstName = "Carl",
                LastName = "Carpenter",
                MiddleInital = "C",
            });
            context.InstructorModels.AddOrUpdate(new InstructorModel
            {
                ID = 2,
                IsAdmin = false,
                FirstName = "Donna",
                LastName = "Dorisdotter",
                MiddleInital = "D",
            });
            context.WorkModels.AddOrUpdate(new WorkModel
            {
                ID = 1,
                Title = "True and False Lesson 1",
                AnswerID = 1,
                QuestionsID = 1,
                IsProgramming = false,
                InstructionText = "Answer these three true/false quesions.",
            });
            context.WorkModels.AddOrUpdate(new WorkModel
            {
                ID = 2,
                Title = "Multiple Choice Lesson 2",
                AnswerID = 2,
                QuestionsID = 2,
                IsProgramming = false,
                InstructionText = "Answer these multiple choice quesions by typing in the number.",
            });
            context.WorkModels.AddOrUpdate(new WorkModel
            {
                ID = 3,
                Title = "String Match Lesson 3",
                AnswerID = 3,
                QuestionsID = 3,
                IsProgramming = false,
                InstructionText = "Answer these three quesions.",
            });
            context.LessonModels.AddOrUpdate(new LessonModel
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
            context.LessonModels.AddOrUpdate(new LessonModel
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
                VideoHtml = "https://www.youtube.com/embed/cpPG0bKHYKc?rel=0",
                WorkID = 2,
            });
            context.LessonModels.AddOrUpdate(new LessonModel
            {
                ID = 3,
                CourseID = 1,
                HasVideo = true,
                IntroText = "Welcome to the last lesson!",
                LessonDataID = 3,
                NextLessonIDs = -1,
                PreviousLessonIDs = 2,
                TemplateID = 1,
                Title = "Learning about being a programmer!",
                VideoHtml = "https://www.youtube.com/embed/1F_OgqRuSdI?rel=0",
                WorkID = 3,
            });
            context.CourseModels.AddOrUpdate(new CourseModel
            {
                ID = 1,
                Title = "Intro to Programming",
                Description = "In this course you will learn basic information about programming.",
                InstructorID = 2,
                LessonOrderByID = new List<int>(new int[]
                {
                    1,2,3
                }),
                StudentIDs = new List<int>(new int[]
                {
                    1,2
                }),
                Students = context.StudentModels.Where(f => f.ID < 3).ToList(),
                Lessons = context.LessonModels.Where(f=>f.ID < 4).ToList(),
                Homeworks = context.WorkModels.Where(f=>f.ID<4).ToList()
            });

            // Creates or Updates the Roles
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "Student" }
                );

            //// Assigns a User a role
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

        }
    }
}
