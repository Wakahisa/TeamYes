namespace startAppA1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedManyModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        InstructorModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstructorModels", t => t.InstructorModel_ID)
                .Index(t => t.InstructorModel_ID);
            
            CreateTable(
                "dbo.WorkModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InstructionText = c.String(),
                        TemplateID = c.Int(nullable: false),
                        WorkSetID = c.Int(nullable: false),
                        LessonID = c.Int(nullable: false),
                        AnswerID = c.Int(nullable: false),
                        Grade = c.Double(nullable: false),
                        InstructorNotes = c.String(),
                        Passed = c.Boolean(nullable: false),
                        IsProgramming = c.Boolean(nullable: false),
                        CourseModel_ID = c.Int(),
                        StudentModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CourseModels", t => t.CourseModel_ID)
                .ForeignKey("dbo.StudentModels", t => t.StudentModel_ID)
                .Index(t => t.CourseModel_ID)
                .Index(t => t.StudentModel_ID);
            
            CreateTable(
                "dbo.LessonModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IntroText = c.String(),
                        TemplateID = c.Int(nullable: false),
                        DataID = c.Int(nullable: false),
                        OpenAtTime = c.DateTime(nullable: false),
                        CloseAtTime = c.DateTime(nullable: false),
                        TimeLimit = c.DateTime(nullable: false),
                        HasVideo = c.Boolean(nullable: false),
                        VideoHtml = c.String(),
                        WorkItem_ID = c.Int(),
                        CourseModel_ID = c.Int(),
                        StudentModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.WorkModels", t => t.WorkItem_ID)
                .ForeignKey("dbo.CourseModels", t => t.CourseModel_ID)
                .ForeignKey("dbo.StudentModels", t => t.StudentModel_ID)
                .Index(t => t.WorkItem_ID)
                .Index(t => t.CourseModel_ID)
                .Index(t => t.StudentModel_ID);
            
            CreateTable(
                "dbo.StudentModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleInital = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GradeModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CurrentTotalGrade = c.Double(nullable: false),
                        StudentModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StudentModels", t => t.StudentModel_ID)
                .Index(t => t.StudentModel_ID);
            
            CreateTable(
                "dbo.InstructorModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleInital = c.String(),
                        LastName = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseModels", "InstructorModel_ID", "dbo.InstructorModels");
            DropForeignKey("dbo.LessonModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.WorkModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.StudentModelCourseModels", "CourseModel_ID", "dbo.CourseModels");
            DropForeignKey("dbo.StudentModelCourseModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.GradeModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.LessonModels", "CourseModel_ID", "dbo.CourseModels");
            DropForeignKey("dbo.LessonModels", "WorkItem_ID", "dbo.WorkModels");
            DropForeignKey("dbo.WorkModels", "CourseModel_ID", "dbo.CourseModels");
            DropIndex("dbo.StudentModelCourseModels", new[] { "CourseModel_ID" });
            DropIndex("dbo.StudentModelCourseModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.GradeModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.LessonModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.LessonModels", new[] { "CourseModel_ID" });
            DropIndex("dbo.LessonModels", new[] { "WorkItem_ID" });
            DropIndex("dbo.WorkModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.WorkModels", new[] { "CourseModel_ID" });
            DropIndex("dbo.CourseModels", new[] { "InstructorModel_ID" });
            DropTable("dbo.StudentModelCourseModels");
            DropTable("dbo.InstructorModels");
            DropTable("dbo.GradeModels");
            DropTable("dbo.StudentModels");
            DropTable("dbo.LessonModels");
            DropTable("dbo.WorkModels");
            DropTable("dbo.CourseModels");
        }
    }
}
