namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryResetLists : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkModels", "CourseModel_ID", "dbo.CourseModels");
            DropForeignKey("dbo.StudentModelCourseModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.StudentModelCourseModels", "CourseModel_ID", "dbo.CourseModels");
            DropForeignKey("dbo.WorkModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.StringAnswerModels", "AnswerModelID", "dbo.AnswerModels");
            DropForeignKey("dbo.CourseModels", "InstructorID", "dbo.InstructorModels");
            DropForeignKey("dbo.StringQuestionModels", "QuestionModelID", "dbo.QuestionsModels");
            DropForeignKey("dbo.LessonModels", "CourseID", "dbo.CourseModels");
            DropForeignKey("dbo.GradeModels", "StudentID", "dbo.StudentModels");
            DropIndex("dbo.StringAnswerModels", new[] { "AnswerModelID" });
            DropIndex("dbo.CourseModels", new[] { "InstructorID" });
            DropIndex("dbo.WorkModels", new[] { "CourseModel_ID" });
            DropIndex("dbo.WorkModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.StringQuestionModels", new[] { "QuestionModelID" });
            DropIndex("dbo.LessonModels", new[] { "CourseID" });
            DropIndex("dbo.GradeModels", new[] { "StudentID" });
            DropIndex("dbo.StudentModelCourseModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.StudentModelCourseModels", new[] { "CourseModel_ID" });
            AlterColumn("dbo.StringAnswerModels", "AnswerModelID", c => c.Int());
            AlterColumn("dbo.CourseModels", "InstructorID", c => c.Int());
            AlterColumn("dbo.StringQuestionModels", "QuestionModelID", c => c.Int());
            AlterColumn("dbo.LessonModels", "CourseID", c => c.Int());
            AlterColumn("dbo.GradeModels", "StudentID", c => c.Int());
            CreateIndex("dbo.CourseModels", "InstructorID");
            CreateIndex("dbo.GradeModels", "StudentID");
            CreateIndex("dbo.LessonModels", "CourseID");
            CreateIndex("dbo.StringAnswerModels", "AnswerModelID");
            CreateIndex("dbo.StringQuestionModels", "QuestionModelID");
            AddForeignKey("dbo.StringAnswerModels", "AnswerModelID", "dbo.AnswerModels", "ID");
            AddForeignKey("dbo.CourseModels", "InstructorID", "dbo.InstructorModels", "ID");
            AddForeignKey("dbo.StringQuestionModels", "QuestionModelID", "dbo.QuestionsModels", "ID");
            AddForeignKey("dbo.LessonModels", "CourseID", "dbo.CourseModels", "ID");
            AddForeignKey("dbo.GradeModels", "StudentID", "dbo.StudentModels", "ID");
            DropColumn("dbo.WorkModels", "CourseModel_ID");
            DropColumn("dbo.WorkModels", "StudentModel_ID");
            DropTable("dbo.StudentModelCourseModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentModelCourseModels",
                c => new
                    {
                        StudentModel_ID = c.Int(nullable: false),
                        CourseModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentModel_ID, t.CourseModel_ID });
            
            AddColumn("dbo.WorkModels", "StudentModel_ID", c => c.Int());
            AddColumn("dbo.WorkModels", "CourseModel_ID", c => c.Int());
            DropForeignKey("dbo.GradeModels", "StudentID", "dbo.StudentModels");
            DropForeignKey("dbo.LessonModels", "CourseID", "dbo.CourseModels");
            DropForeignKey("dbo.StringQuestionModels", "QuestionModelID", "dbo.QuestionsModels");
            DropForeignKey("dbo.CourseModels", "InstructorID", "dbo.InstructorModels");
            DropForeignKey("dbo.StringAnswerModels", "AnswerModelID", "dbo.AnswerModels");
            DropIndex("dbo.StringQuestionModels", new[] { "QuestionModelID" });
            DropIndex("dbo.StringAnswerModels", new[] { "AnswerModelID" });
            DropIndex("dbo.LessonModels", new[] { "CourseID" });
            DropIndex("dbo.GradeModels", new[] { "StudentID" });
            DropIndex("dbo.CourseModels", new[] { "InstructorID" });
            AlterColumn("dbo.GradeModels", "StudentID", c => c.Int(nullable: false));
            AlterColumn("dbo.LessonModels", "CourseID", c => c.Int(nullable: false));
            AlterColumn("dbo.StringQuestionModels", "QuestionModelID", c => c.Int(nullable: false));
            AlterColumn("dbo.CourseModels", "InstructorID", c => c.Int(nullable: false));
            AlterColumn("dbo.StringAnswerModels", "AnswerModelID", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentModelCourseModels", "CourseModel_ID");
            CreateIndex("dbo.StudentModelCourseModels", "StudentModel_ID");
            CreateIndex("dbo.GradeModels", "StudentID");
            CreateIndex("dbo.LessonModels", "CourseID");
            CreateIndex("dbo.StringQuestionModels", "QuestionModelID");
            CreateIndex("dbo.WorkModels", "StudentModel_ID");
            CreateIndex("dbo.WorkModels", "CourseModel_ID");
            CreateIndex("dbo.CourseModels", "InstructorID");
            CreateIndex("dbo.StringAnswerModels", "AnswerModelID");
            AddForeignKey("dbo.GradeModels", "StudentID", "dbo.StudentModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.LessonModels", "CourseID", "dbo.CourseModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StringQuestionModels", "QuestionModelID", "dbo.QuestionsModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CourseModels", "InstructorID", "dbo.InstructorModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StringAnswerModels", "AnswerModelID", "dbo.AnswerModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.WorkModels", "StudentModel_ID", "dbo.StudentModels", "ID");
            AddForeignKey("dbo.StudentModelCourseModels", "CourseModel_ID", "dbo.CourseModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StudentModelCourseModels", "StudentModel_ID", "dbo.StudentModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.WorkModels", "CourseModel_ID", "dbo.CourseModels", "ID");
        }
    }
}
