namespace startAppA1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodelsseededawholecourse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.CourseModels", "StudentID", "dbo.StudentModels");
            DropForeignKey("dbo.StudentModels", "CourseModel_ID", "dbo.CourseModels");
            DropIndex("dbo.CourseModels", new[] { "StudentID" });
            DropIndex("dbo.CourseModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.StudentModels", new[] { "CourseModel_ID" });
            CreateTable(
                "dbo.AnswerModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        TrueFalse = c.Boolean(nullable: false),
                        MultipleChoice = c.Boolean(nullable: false),
                        StringMatching = c.Boolean(nullable: false),
                        GradeByHand = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.QuestionstModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LessonDataModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Placeholder = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentModelCourseModels",
                c => new
                    {
                        StudentModel_ID = c.Int(nullable: false),
                        CourseModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentModel_ID, t.CourseModel_ID })
                .ForeignKey("dbo.StudentModels", t => t.StudentModel_ID, cascadeDelete: true)
                .ForeignKey("dbo.CourseModels", t => t.CourseModel_ID, cascadeDelete: true)
                .Index(t => t.StudentModel_ID)
                .Index(t => t.CourseModel_ID);
            
            AddColumn("dbo.WorkModels", "QuestionsID", c => c.Int());
            AddColumn("dbo.WorkModels", "Answers_ID", c => c.Int());
            AddColumn("dbo.InstructorModels", "LoginName", c => c.String());
            AddColumn("dbo.InstructorModels", "Password", c => c.String());
            AddColumn("dbo.InstructorModels", "PasswordShield", c => c.String());
            AddColumn("dbo.LessonModels", "LessonDataID", c => c.Int());
            AddColumn("dbo.LessonModels", "WorkID", c => c.Int());
            AddColumn("dbo.StudentModels", "LoginName", c => c.String());
            AddColumn("dbo.StudentModels", "Password", c => c.String());
            AddColumn("dbo.StudentModels", "PasswordShield", c => c.String());
            AlterColumn("dbo.WorkModels", "TemplateID", c => c.Int());
            AlterColumn("dbo.WorkModels", "AnswerID", c => c.Int());
            CreateIndex("dbo.WorkModels", "QuestionsID");
            CreateIndex("dbo.WorkModels", "Answers_ID");
            CreateIndex("dbo.LessonModels", "LessonDataID");
            AddForeignKey("dbo.WorkModels", "Answers_ID", "dbo.AnswerModels", "ID");
            AddForeignKey("dbo.WorkModels", "QuestionsID", "dbo.QuestionstModels", "ID");
            AddForeignKey("dbo.LessonModels", "LessonDataID", "dbo.LessonDataModels", "ID");
            DropColumn("dbo.CourseModels", "StudentID");
            DropColumn("dbo.CourseModels", "StudentModel_ID");
            DropColumn("dbo.WorkModels", "WorkSetID");
            DropColumn("dbo.WorkModels", "LessonID");
            DropColumn("dbo.LessonModels", "DataID");
            DropColumn("dbo.StudentModels", "CourseModel_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentModels", "CourseModel_ID", c => c.Int());
            AddColumn("dbo.LessonModels", "DataID", c => c.Int(nullable: false));
            AddColumn("dbo.WorkModels", "LessonID", c => c.Int(nullable: false));
            AddColumn("dbo.WorkModels", "WorkSetID", c => c.Int(nullable: false));
            AddColumn("dbo.CourseModels", "StudentModel_ID", c => c.Int());
            AddColumn("dbo.CourseModels", "StudentID", c => c.Int());
            DropForeignKey("dbo.StudentModelCourseModels", "CourseModel_ID", "dbo.CourseModels");
            DropForeignKey("dbo.StudentModelCourseModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.LessonModels", "LessonDataID", "dbo.LessonDataModels");
            DropForeignKey("dbo.WorkModels", "QuestionsID", "dbo.QuestionstModels");
            DropForeignKey("dbo.WorkModels", "Answers_ID", "dbo.AnswerModels");
            DropIndex("dbo.StudentModelCourseModels", new[] { "CourseModel_ID" });
            DropIndex("dbo.StudentModelCourseModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.LessonModels", new[] { "LessonDataID" });
            DropIndex("dbo.WorkModels", new[] { "Answers_ID" });
            DropIndex("dbo.WorkModels", new[] { "QuestionsID" });
            AlterColumn("dbo.WorkModels", "AnswerID", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkModels", "TemplateID", c => c.Int(nullable: false));
            DropColumn("dbo.StudentModels", "PasswordShield");
            DropColumn("dbo.StudentModels", "Password");
            DropColumn("dbo.StudentModels", "LoginName");
            DropColumn("dbo.LessonModels", "WorkID");
            DropColumn("dbo.LessonModels", "LessonDataID");
            DropColumn("dbo.InstructorModels", "PasswordShield");
            DropColumn("dbo.InstructorModels", "Password");
            DropColumn("dbo.InstructorModels", "LoginName");
            DropColumn("dbo.WorkModels", "Answers_ID");
            DropColumn("dbo.WorkModels", "QuestionsID");
            DropTable("dbo.StudentModelCourseModels");
            DropTable("dbo.LessonDataModels");
            DropTable("dbo.QuestionstModels");
            DropTable("dbo.AnswerModels");
            CreateIndex("dbo.StudentModels", "CourseModel_ID");
            CreateIndex("dbo.CourseModels", "StudentModel_ID");
            CreateIndex("dbo.CourseModels", "StudentID");
            AddForeignKey("dbo.StudentModels", "CourseModel_ID", "dbo.CourseModels", "ID");
            AddForeignKey("dbo.CourseModels", "StudentID", "dbo.StudentModels", "ID");
            AddForeignKey("dbo.CourseModels", "StudentModel_ID", "dbo.StudentModels", "ID");
        }
    }
}
