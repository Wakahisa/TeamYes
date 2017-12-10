namespace IdentityNew.Migrations
{
    using IdentityNew.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityNew.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdentityNew.Models.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            /// <summary>
            /// Add models
            /// </summary>
            #region lesson data model

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

            #endregion

            //#region questionmodels

            //context.QuestionModels.AddOrUpdate(new QuestionsModel
            //{
            //    ID = 1,
            //    Title = "L1TrueFalseQs",
            //});
            //var questionSet = new List<StringQuestionModel>(new StringQuestionModel[] { new StringQuestionModel("You use a double type of variable to hold decimal numbers.") { QuestionModelID = 1 },
            //                                                                new StringQuestionModel("You cannot duplicate the effects of nested if/then/else with a switch statement.") { QuestionModelID = 1 },
            //                                                                new StringQuestionModel("A private class variable can be called by functions in a different class.") { QuestionModelID = 1 }
            //    });
            //var questionSetModel = context.QuestionModels.FirstOrDefault(c => c.ID == 1);
            //questionSetModel.Questions = questionSet;
            //context.QuestionModels.AddOrUpdate(questionSetModel);

            //context.QuestionModels.AddOrUpdate(new QuestionsModel
            //{
            //    ID = 2,
            //    Title = "L2MultipleChoiceQs",

            //});
            //questionSet = new List<StringQuestionModel>(new StringQuestionModel[] { new StringQuestionModel("A class is:   1. A file   2. An object   3. Both   4. Neither   5. More complicated than that"){ QuestionModelID = 2 },
            //                                                                new StringQuestionModel("How many bits are in a byte?   1. Two bits   2. Four bits   3. Six bits   4. Eight bits"){ QuestionModelID = 2 },
            //                                                                new StringQuestionModel("Pointers are:  1. God's gift to programmers.   2. A horror that programming languages have outgrown.   3. I like lasers!   4. What's a pointer?"){ QuestionModelID = 2 }
            //    });
            //questionSetModel = context.QuestionModels.FirstOrDefault(c => c.ID == 2);
            //questionSetModel.Questions = questionSet;
            //context.QuestionModels.AddOrUpdate(questionSetModel);

            //context.QuestionModels.AddOrUpdate(new QuestionsModel
            //{
            //    ID = 3,
            //    Title = "L3StringMatchQs",
            //});
            //questionSet = new List<StringQuestionModel>(new StringQuestionModel[] { new StringQuestionModel("What programming language does this class teach?"){ QuestionModelID = 3 },
            //                                                                new StringQuestionModel("What number does the index of a list start at?"){ QuestionModelID = 3 },
            //                                                                new StringQuestionModel("Rewrite the following line of code correctly: public void FindAndReturnIdNumberOfPersonByName (long nameVariable)"){ QuestionModelID = 3 }
            //    });
            //questionSetModel = context.QuestionModels.FirstOrDefault(c => c.ID == 3);
            //questionSetModel.Questions = questionSet;
            //context.QuestionModels.AddOrUpdate(questionSetModel);

            //#endregion

            //#region answermodels
            //context.AnswerModels.AddOrUpdate(new AnswerModel
            //{
            //    ID = 1,
            //    Title = "L1TrueFalseAnswers",
            //    GradeByHand = false,
            //    MultipleChoice = false,
            //    StringMatching = false,
            //    TrueFalse = true,
            //    TrueFalseAnswers = new List<bool>(new bool[]
            //    {
            //        true,true,false
            //    }),
            //});
            //var answerSet = new List<StringAnswerModel>(new StringAnswerModel[]
            //    {
            //        new StringAnswerModel("true"){ AnswerModelID = 1 },
            //        new StringAnswerModel("true"){ AnswerModelID = 1 },
            //        new StringAnswerModel("false"){ AnswerModelID = 1 }
            //    });
            //var answerSetModel = context.AnswerModels.FirstOrDefault(c => c.ID == 1);
            //answerSetModel.Answers = answerSet;
            //context.AnswerModels.AddOrUpdate(answerSetModel);

            //context.AnswerModels.AddOrUpdate(new AnswerModel
            //{
            //    ID = 2,
            //    Title = "L2MultipleChoiceAnswers",
            //    GradeByHand = false,
            //    MultipleChoice = true,
            //    StringMatching = false,
            //    TrueFalse = false,
            //    MultiChoiceAnswers = new List<int>(new int[]
            //    {
            //        5,4,3
            //    }),
            //});
            //answerSet = new List<StringAnswerModel>(new StringAnswerModel[]
            //    {
            //        new StringAnswerModel("5"){ AnswerModelID = 2 },
            //        new StringAnswerModel("4"){ AnswerModelID = 2 },
            //        new StringAnswerModel("3"){ AnswerModelID = 2 }
            //    });
            //answerSetModel = context.AnswerModels.FirstOrDefault(c => c.ID == 2);
            //answerSetModel.Answers = answerSet;
            //context.AnswerModels.AddOrUpdate(answerSetModel);

            //context.AnswerModels.AddOrUpdate(new AnswerModel
            //{
            //    ID = 3,
            //    Title = "L3StringMatchAnswers",
            //    GradeByHand = false,
            //    MultipleChoice = false,
            //    StringMatching = true,
            //    TrueFalse = false,
            //    StringMatchAnswers = new List<string>(new string[]
            //    {
            //        "python","0","public int FindAndReturnIdNumberOfPersonByName (string nameVariable)"
            //    }),
            //});
            //answerSet = new List<StringAnswerModel>(new StringAnswerModel[]
            //    {
            //        new StringAnswerModel("python"){ AnswerModelID = 3 },
            //        new StringAnswerModel("0"){ AnswerModelID = 3 },
            //        new StringAnswerModel("public int FindAndReturnIdNumberOfPersonByName (string nameVariable)"){ AnswerModelID = 3 }
            //    });
            //answerSetModel = context.AnswerModels.FirstOrDefault(c => c.ID == 3);
            //answerSetModel.Answers = answerSet;
            //context.AnswerModels.AddOrUpdate(answerSetModel);

            //// a set of answers for student 1
            //answerSet = new List<StringAnswerModel>(new StringAnswerModel[]
            //    {
            //        new StringAnswerModel("true"){ AnswerModelID = 4 },
            //        new StringAnswerModel("false"){ AnswerModelID = 4 },
            //        new StringAnswerModel("false"){ AnswerModelID = 4 }
            //    });
            //context.AnswerModels.AddOrUpdate(new AnswerModel
            //{
            //    ID = 4,
            //    Title = "L1TrueFalseAnswers",
            //    GradeByHand = false,
            //    MultipleChoice = false,
            //    StringMatching = false,
            //    TrueFalse = true,
            //    TrueFalseAnswers = new List<bool>(new bool[]
            //    {
            //        true,false,false
            //    }),
            //    Answers = answerSet
            //});

            //// a set of answers for student 1
            //answerSet = new List<StringAnswerModel>(new StringAnswerModel[]
            //    {
            //        new StringAnswerModel("5"){ AnswerModelID = 5 },
            //        new StringAnswerModel("1"){ AnswerModelID = 5 },
            //        new StringAnswerModel("3"){ AnswerModelID = 5 }
            //    });
            //context.AnswerModels.AddOrUpdate(new AnswerModel
            //{
            //    ID = 5,
            //    Title = "L2MultipleChoiceAnswers",
            //    GradeByHand = false,
            //    MultipleChoice = true,
            //    StringMatching = false,
            //    TrueFalse = false,
            //    MultiChoiceAnswers = new List<int>(new int[]
            //    {
            //        5,1,3
            //    }),
            //    Answers = answerSet
            //});

            //// a set of answers for student 2
            //answerSet = new List<StringAnswerModel>(new StringAnswerModel[]
            //    {
            //        new StringAnswerModel("true"){ AnswerModelID = 6 },
            //        new StringAnswerModel("true"){ AnswerModelID = 6 },
            //        new StringAnswerModel("true"){ AnswerModelID = 6 }
            //    });
            //context.AnswerModels.AddOrUpdate(new AnswerModel
            //{
            //    ID = 6,
            //    Title = "L1TrueFalseAnswers",
            //    GradeByHand = false,
            //    MultipleChoice = false,
            //    StringMatching = false,
            //    TrueFalse = true,
            //    TrueFalseAnswers = new List<bool>(new bool[]
            //    {
            //        true,true,true
            //    }),
            //});

            //#endregion

            #region user models
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
            #endregion

            //#region work models

            //context.WorkModels.AddOrUpdate(new WorkModel
            //{
            //    ID = 1,
            //    Title = "True and False Lesson 1",
            //    AnswerID = 1,
            //    QuestionsID = 1,
            //    IsProgramming = false,
            //    InstructionText = "Answer these three true/false quesions.",
            //});
            //context.WorkModels.AddOrUpdate(new WorkModel
            //{
            //    ID = 2,
            //    Title = "Multiple Choice Lesson 2",
            //    AnswerID = 2,
            //    QuestionsID = 2,
            //    IsProgramming = false,
            //    InstructionText = "Answer these multiple choice quesions by typing in the number.",
            //});
            //context.WorkModels.AddOrUpdate(new WorkModel
            //{
            //    ID = 3,
            //    Title = "String Match Lesson 3",
            //    AnswerID = 3,
            //    QuestionsID = 3,
            //    IsProgramming = false,
            //    InstructionText = "Answer these three quesions.",
            //});

            //#endregion

            #region lesson models

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

            #endregion

            #region course models

            context.CourseModels.AddOrUpdate(new CourseModel
            {
                ID = 1,
                Title = "Intro to Programming 1",
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
                Lessons = context.LessonModels.Where(f => f.ID < 4).ToList(),
                Homeworks = context.WorkModels.Where(f => f.ID < 4).ToList()
            });
            context.CourseModels.AddOrUpdate(new CourseModel
            {
                ID = 2,
                Title = "Intro to Programming 2",
                Description = "In this course you will learn basic information about programming.",
                InstructorID = 2,
                Lessons = context.LessonModels.Where(f => f.ID < 4).ToList(),
                Homeworks = context.WorkModels.Where(f => f.ID < 4).ToList(),
                LessonOrderByID = new List<int>(new int[]
                {
                    3,2,1
                }),
            });
            context.CourseModels.AddOrUpdate(new CourseModel
            {
                ID = 3,
                Title = "Intro to Programming 3",
                Description = "In this course you will learn basic information about programming.",
                InstructorID = 2,
                Lessons = context.LessonModels.Where(f => f.ID < 4).ToList(),
                Homeworks = context.WorkModels.Where(f => f.ID < 4).ToList(),
                LessonOrderByID = new List<int>(new int[]
                {
                    3,1,2
                }),
            });

            #endregion

            //#region add info to students


            //context.SaveChanges();

            //var tempStudent = context.StudentModels.FirstOrDefault(s => s.ID == 1);
            //var student1 = new StudentModel();
            //student1 = tempStudent;
            //student1.CourseIDs = new List<int>() { 1 };
            //var les1 = new LessonModel();
            //var tempLesson = context.LessonModels.FirstOrDefault(x => x.ID == 1);
            //les1.HasVideo = tempLesson.HasVideo; les1.IntroText = tempLesson.IntroText; les1.LessonData = tempLesson.LessonData; les1.LessonDataID = tempLesson.LessonDataID; les1.NextLessonIDs = tempLesson.NextLessonIDs; les1.Title = tempLesson.Title; les1.VideoHtml = tempLesson.VideoHtml;
            //les1.ID = 4; // duplicate of lesson 1
            //les1.Students = new List<StudentModel>() { student1 };
            //var work1 = new WorkModel();
            //var tempWork = context.WorkModels.FirstOrDefault(x => x.ID == 1);
            //work1.InstructionText = tempWork.InstructionText; work1.InstructionText = tempWork.InstructionText; work1.InstructorNotes = tempWork.InstructorNotes; work1.IsProgramming = tempWork.IsProgramming; work1.Questions = tempWork.Questions; work1.QuestionsID = tempWork.QuestionsID; work1.Title = tempWork.Title;
            //work1.ID = 4;
            //work1.AnswerID = 4; // duplicate of work 1 with ansewer = db index 4 of answers
            //work1.Answers = context.AnswerModels.FirstOrDefault(x => x.ID == 4);
            //work1.Grade = 100;
            //work1.Passed = true;
            //work1.Students.Add(student1);
            //context.WorkModels.AddOrUpdate(work1);
            //les1.WorkID = 4;
            //les1.WorkItem = work1;
            //context.LessonModels.AddOrUpdate(les1);
            //// next set for student 1
            //tempLesson = context.LessonModels.FirstOrDefault(x => x.ID == 1);
            //var les2 = new LessonModel();
            //les2.HasVideo = tempLesson.HasVideo; les2.IntroText = tempLesson.IntroText; les2.LessonData = tempLesson.LessonData; les2.LessonDataID = tempLesson.LessonDataID; les2.NextLessonIDs = tempLesson.NextLessonIDs; les2.Title = tempLesson.Title; les2.VideoHtml = tempLesson.VideoHtml;
            //les2.ID = 5; // duplicate of lesson 2
            //les2.Students = new List<StudentModel>() { student1 };
            //tempWork = context.WorkModels.FirstOrDefault(x => x.ID == 1);
            //var work2 = new WorkModel();
            //work2.InstructionText = tempWork.InstructionText; work2.InstructionText = tempWork.InstructionText; work2.InstructorNotes = tempWork.InstructorNotes; work2.IsProgramming = tempWork.IsProgramming; work2.Questions = tempWork.Questions; work2.QuestionsID = tempWork.QuestionsID; work2.Title = tempWork.Title;
            //work2.ID = 5;
            //work2.Students.Add(student1);
            //work2.AnswerID = 5; // duplicate of work 2 with ansewer = db index 5 of answers
            //work2.Answers = context.AnswerModels.FirstOrDefault(x => x.ID == 5);
            //work2.Grade = 66.6;
            //work2.Passed = false;
            //context.WorkModels.AddOrUpdate(work2);
            //les2.WorkID = 5;
            //les2.WorkItem = work2;
            //context.LessonModels.AddOrUpdate(les2);
            //context.StudentModels.AddOrUpdate(student1);


            //var student2 = new StudentModel();
            //tempStudent = context.StudentModels.FirstOrDefault(s => s.ID == 2);
            //student2 = tempStudent;
            //student1.CourseIDs = new List<int>() { 1 };
            //tempLesson = context.LessonModels.FirstOrDefault(x => x.ID == 1);
            //var les3 = new LessonModel();
            //les3.HasVideo = tempLesson.HasVideo; les3.IntroText = tempLesson.IntroText; les3.LessonData = tempLesson.LessonData; les3.LessonDataID = tempLesson.LessonDataID; les3.NextLessonIDs = tempLesson.NextLessonIDs; les3.Title = tempLesson.Title; les3.VideoHtml = tempLesson.VideoHtml;
            //les3.ID = 6; // duplicate of lesson 1
            //les3.Students = new List<StudentModel>() { student2 };
            //tempWork = context.WorkModels.FirstOrDefault(x => x.ID == 1);
            //var work3 = new WorkModel();
            //work3.InstructionText = tempWork.InstructionText; work3.InstructionText = tempWork.InstructionText; work3.InstructorNotes = tempWork.InstructorNotes; work3.IsProgramming = tempWork.IsProgramming; work3.Questions = tempWork.Questions; work3.QuestionsID = tempWork.QuestionsID; work3.Title = tempWork.Title;
            //work3.ID = 6;
            //work3.Students.Add(student2);
            //work3.AnswerID = 6; // duplicate of work 1 with ansewer = db index 6 of answers
            //work3.Answers = context.AnswerModels.FirstOrDefault(x => x.ID == 6);
            //work3.Grade = 33.3;
            //work3.Passed = false;
            //context.WorkModels.AddOrUpdate(work3);
            //les3.WorkID = 6;
            //les3.WorkItem = work3;
            //context.LessonModels.AddOrUpdate(les3);


            //#endregion
            context.SaveChanges();

            // Creates or Updates the Roles
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "Student" }
                );

            // Assigns a User a role
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //UserManager.AddToRole("1594e4ae-5fc2-45b3-86ee-efa4e635df27", "Admin"); // ("UserID", "User Role")
            UserManager.AddToRole("2e6b8ed2-5509-4c7f-895f-570e0f29a97d", "Admin"); // ("UserID", "User Role")
        }
    }
}
