namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cmonFixAlreadyNew : DbMigration
    {
        public override void Up()
        {
           // RenameTable(name: "dbo.CourseModelStudentModels", newName: "StudentModelCourseModels");
            DropForeignKey("dbo.StringAnswers", "AnswerModelID", "dbo.AnswerModels");
            DropForeignKey("dbo.CourseModels", "InstructorID", "dbo.InstructorModels");
            DropForeignKey("dbo.LessonModels", "CourseID", "dbo.CourseModels");
            DropForeignKey("dbo.StringQuestions", "QuestionModelID", "dbo.QuestionsModels");
            DropForeignKey("dbo.GradeModels", "StudentID", "dbo.StudentModels");
            DropIndex("dbo.StringAnswers", new[] { "AnswerModelID" });
            DropIndex("dbo.CourseModels", new[] { "InstructorID" });
            DropIndex("dbo.StringQuestions", new[] { "QuestionModelID" });
            DropIndex("dbo.LessonModels", new[] { "CourseID" });
            DropIndex("dbo.GradeModels", new[] { "StudentID" });
            DropPrimaryKey("dbo.StudentModelCourseModels");
            AddColumn("dbo.StringAnswers", "AnswerModelID", c => c.Int());
            AlterColumn("dbo.StringAnswers", "AnswerModelID", c => c.Int(nullable: false));
            AlterColumn("dbo.CourseModels", "InstructorID", c => c.Int(nullable: false));
            AddColumn("dbo.StringQuestions", "QuestionModelID", c => c.Int());
            AlterColumn("dbo.StringQuestions", "QuestionModelID", c => c.Int(nullable: false));
            AlterColumn("dbo.LessonModels", "CourseID", c => c.Int(nullable: false));
            AlterColumn("dbo.GradeModels", "StudentID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.StudentModelCourseModels", new[] { "StudentModel_ID", "CourseModel_ID" });
            CreateIndex("dbo.StringAnswers", "AnswerModelID");
            CreateIndex("dbo.CourseModels", "InstructorID");
            CreateIndex("dbo.StringQuestions", "QuestionModelID");
            CreateIndex("dbo.LessonModels", "CourseID");
            CreateIndex("dbo.GradeModels", "StudentID");
            AddForeignKey("dbo.StringAnswers", "AnswerModelID", "dbo.AnswerModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CourseModels", "InstructorID", "dbo.InstructorModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.LessonModels", "CourseID", "dbo.CourseModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StringQuestions", "QuestionModelID", "dbo.QuestionsModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.GradeModels", "StudentID", "dbo.StudentModels", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GradeModels", "StudentID", "dbo.StudentModels");
            DropForeignKey("dbo.StringQuestions", "QuestionModelID", "dbo.QuestionsModels");
            DropForeignKey("dbo.LessonModels", "CourseID", "dbo.CourseModels");
            DropForeignKey("dbo.CourseModels", "InstructorID", "dbo.InstructorModels");
            DropForeignKey("dbo.StringAnswers", "AnswerModelID", "dbo.AnswerModels");
            DropIndex("dbo.GradeModels", new[] { "StudentID" });
            DropIndex("dbo.LessonModels", new[] { "CourseID" });
            DropIndex("dbo.StringQuestions", new[] { "QuestionModelID" });
            DropIndex("dbo.CourseModels", new[] { "InstructorID" });
            DropIndex("dbo.StringAnswers", new[] { "AnswerModelID" });
            DropPrimaryKey("dbo.StudentModelCourseModels");
            AlterColumn("dbo.GradeModels", "StudentID", c => c.Int());
            AlterColumn("dbo.LessonModels", "CourseID", c => c.Int());
            AlterColumn("dbo.StringQuestions", "QuestionModelID", c => c.Int());
            AlterColumn("dbo.CourseModels", "InstructorID", c => c.Int());
            AlterColumn("dbo.StringAnswers", "AnswerModelID", c => c.Int());
            AddPrimaryKey("dbo.StudentModelCourseModels", new[] { "CourseModel_ID", "StudentModel_ID" });
            CreateIndex("dbo.GradeModels", "StudentID");
            CreateIndex("dbo.LessonModels", "CourseID");
            CreateIndex("dbo.StringQuestions", "QuestionModelID");
            CreateIndex("dbo.CourseModels", "InstructorID");
            CreateIndex("dbo.StringAnswers", "AnswerModelID");
            AddForeignKey("dbo.GradeModels", "StudentID", "dbo.StudentModels", "ID");
            AddForeignKey("dbo.StringQuestions", "QuestionModelID", "dbo.QuestionsModels", "ID");
            AddForeignKey("dbo.LessonModels", "CourseID", "dbo.CourseModels", "ID");
            AddForeignKey("dbo.CourseModels", "InstructorID", "dbo.InstructorModels", "ID");
            AddForeignKey("dbo.StringAnswers", "AnswerModelID", "dbo.AnswerModels", "ID");
            RenameTable(name: "dbo.StudentModelCourseModels", newName: "CourseModelStudentModels");
        }
    }
}
