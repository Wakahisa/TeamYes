namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreResetLists : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StringAnswerModels", "AnswerModelID", "dbo.AnswerModels");
            DropForeignKey("dbo.StringQuestionModels", "QuestionModelID", "dbo.QuestionsModels");
            DropForeignKey("dbo.WorkModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.LessonModels", "StudentID", "dbo.StudentModels");
            DropForeignKey("dbo.CourseModels", "InstructorID", "dbo.InstructorModels");
            DropIndex("dbo.StringAnswerModels", new[] { "AnswerModelID" });
            DropIndex("dbo.WorkModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.StringQuestionModels", new[] { "QuestionModelID" });
            DropIndex("dbo.LessonModels", new[] { "StudentID" });
            CreateTable(
                "dbo.StringAnswerModelAnswerModels",
                c => new
                    {
                        StringAnswerModel_ID = c.Int(nullable: false),
                        AnswerModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StringAnswerModel_ID, t.AnswerModel_ID })
                .ForeignKey("dbo.StringAnswerModels", t => t.StringAnswerModel_ID, cascadeDelete: true)
                .ForeignKey("dbo.AnswerModels", t => t.AnswerModel_ID, cascadeDelete: false)
                .Index(t => t.StringAnswerModel_ID)
                .Index(t => t.AnswerModel_ID);
            
            CreateTable(
                "dbo.StringQuestionModelQuestionsModels",
                c => new
                    {
                        StringQuestionModel_ID = c.Int(nullable: false),
                        QuestionsModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StringQuestionModel_ID, t.QuestionsModel_ID })
                .ForeignKey("dbo.StringQuestionModels", t => t.StringQuestionModel_ID, cascadeDelete: true)
                .ForeignKey("dbo.QuestionsModels", t => t.QuestionsModel_ID, cascadeDelete: false)
                .Index(t => t.StringQuestionModel_ID)
                .Index(t => t.QuestionsModel_ID);
            
            CreateTable(
                "dbo.StudentModelWorkModels",
                c => new
                    {
                        StudentModel_ID = c.Int(nullable: false),
                        WorkModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentModel_ID, t.WorkModel_ID })
                .ForeignKey("dbo.StudentModels", t => t.StudentModel_ID, cascadeDelete: true)
                .ForeignKey("dbo.WorkModels", t => t.WorkModel_ID, cascadeDelete: false)
                .Index(t => t.StudentModel_ID)
                .Index(t => t.WorkModel_ID);
            
            CreateTable(
                "dbo.LessonModelStudentModels",
                c => new
                    {
                        LessonModel_ID = c.Int(nullable: false),
                        StudentModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LessonModel_ID, t.StudentModel_ID })
                .ForeignKey("dbo.LessonModels", t => t.LessonModel_ID, cascadeDelete: true)
                .ForeignKey("dbo.StudentModels", t => t.StudentModel_ID, cascadeDelete: false)
                .Index(t => t.LessonModel_ID)
                .Index(t => t.StudentModel_ID);
            
            AddColumn("dbo.CourseModels", "InstructorModel_ID", c => c.Int());
            AddColumn("dbo.InstructorModels", "CourseModel_ID", c => c.Int());
            CreateIndex("dbo.CourseModels", "InstructorModel_ID");
            CreateIndex("dbo.InstructorModels", "CourseModel_ID");
            AddForeignKey("dbo.InstructorModels", "CourseModel_ID", "dbo.CourseModels", "ID");
            AddForeignKey("dbo.CourseModels", "InstructorModel_ID", "dbo.InstructorModels", "ID");
            DropColumn("dbo.WorkModels", "StudentModel_ID");
            DropColumn("dbo.LessonModels", "StudentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LessonModels", "StudentID", c => c.Int());
            AddColumn("dbo.WorkModels", "StudentModel_ID", c => c.Int());
            DropForeignKey("dbo.CourseModels", "InstructorModel_ID", "dbo.InstructorModels");
            DropForeignKey("dbo.InstructorModels", "CourseModel_ID", "dbo.CourseModels");
            DropForeignKey("dbo.LessonModelStudentModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.LessonModelStudentModels", "LessonModel_ID", "dbo.LessonModels");
            DropForeignKey("dbo.StudentModelWorkModels", "WorkModel_ID", "dbo.WorkModels");
            DropForeignKey("dbo.StudentModelWorkModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.StringQuestionModelQuestionsModels", "QuestionsModel_ID", "dbo.QuestionsModels");
            DropForeignKey("dbo.StringQuestionModelQuestionsModels", "StringQuestionModel_ID", "dbo.StringQuestionModels");
            DropForeignKey("dbo.StringAnswerModelAnswerModels", "AnswerModel_ID", "dbo.AnswerModels");
            DropForeignKey("dbo.StringAnswerModelAnswerModels", "StringAnswerModel_ID", "dbo.StringAnswerModels");
            DropIndex("dbo.LessonModelStudentModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.LessonModelStudentModels", new[] { "LessonModel_ID" });
            DropIndex("dbo.StudentModelWorkModels", new[] { "WorkModel_ID" });
            DropIndex("dbo.StudentModelWorkModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.StringQuestionModelQuestionsModels", new[] { "QuestionsModel_ID" });
            DropIndex("dbo.StringQuestionModelQuestionsModels", new[] { "StringQuestionModel_ID" });
            DropIndex("dbo.StringAnswerModelAnswerModels", new[] { "AnswerModel_ID" });
            DropIndex("dbo.StringAnswerModelAnswerModels", new[] { "StringAnswerModel_ID" });
            DropIndex("dbo.InstructorModels", new[] { "CourseModel_ID" });
            DropIndex("dbo.CourseModels", new[] { "InstructorModel_ID" });
            DropColumn("dbo.InstructorModels", "CourseModel_ID");
            DropColumn("dbo.CourseModels", "InstructorModel_ID");
            DropTable("dbo.LessonModelStudentModels");
            DropTable("dbo.StudentModelWorkModels");
            DropTable("dbo.StringQuestionModelQuestionsModels");
            DropTable("dbo.StringAnswerModelAnswerModels");
            CreateIndex("dbo.LessonModels", "StudentID");
            CreateIndex("dbo.StringQuestionModels", "QuestionModelID");
            CreateIndex("dbo.WorkModels", "StudentModel_ID");
            CreateIndex("dbo.StringAnswerModels", "AnswerModelID");
            AddForeignKey("dbo.CourseModels", "InstructorID", "dbo.InstructorModels", "ID");
            AddForeignKey("dbo.LessonModels", "StudentID", "dbo.StudentModels", "ID");
            AddForeignKey("dbo.WorkModels", "StudentModel_ID", "dbo.StudentModels", "ID");
            AddForeignKey("dbo.StringQuestionModels", "QuestionModelID", "dbo.QuestionsModels", "ID");
            AddForeignKey("dbo.StringAnswerModels", "AnswerModelID", "dbo.AnswerModels", "ID");
        }
    }
}
