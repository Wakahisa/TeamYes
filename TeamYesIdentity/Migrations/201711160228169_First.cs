namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminTableModels",
                c => new
                    {
                        TableID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TableID);
            
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
                "dbo.CourseModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        InstructorID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstructorModels", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.WorkModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TemplateID = c.Int(),
                        Title = c.String(),
                        InstructionText = c.String(),
                        Grade = c.Double(nullable: false),
                        InstructorNotes = c.String(),
                        Passed = c.Boolean(nullable: false),
                        IsProgramming = c.Boolean(nullable: false),
                        QuestionsID = c.Int(),
                        AnswerID = c.Int(),
                        Answers_ID = c.Int(),
                        CourseModel_ID = c.Int(),
                        StudentModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AnswerModels", t => t.Answers_ID)
                .ForeignKey("dbo.QuestionstModels", t => t.QuestionsID)
                .ForeignKey("dbo.CourseModels", t => t.CourseModel_ID)
                .ForeignKey("dbo.StudentModels", t => t.StudentModel_ID)
                .Index(t => t.QuestionsID)
                .Index(t => t.Answers_ID)
                .Index(t => t.CourseModel_ID)
                .Index(t => t.StudentModel_ID);
            
            CreateTable(
                "dbo.QuestionstModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.InstructorModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleInital = c.String(),
                        LastName = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        EmailAddress = c.String(),
                        LoginName = c.String(),
                        Password = c.String(),
                        PasswordShield = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LessonModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IntroText = c.String(),
                        TemplateID = c.Int(nullable: false),
                        NextLessonIDs = c.Int(nullable: false),
                        PreviousLessonIDs = c.Int(nullable: false),
                        OpenAtTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CloseAtTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TimeLimit = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        HasVideo = c.Boolean(nullable: false),
                        VideoHtml = c.String(),
                        CourseID = c.Int(),
                        StudentID = c.Int(),
                        LessonDataID = c.Int(),
                        WorkID = c.Int(),
                        WorkItem_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CourseModels", t => t.CourseID)
                .ForeignKey("dbo.LessonDataModels", t => t.LessonDataID)
                .ForeignKey("dbo.StudentModels", t => t.StudentID)
                .ForeignKey("dbo.WorkModels", t => t.WorkItem_ID)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID)
                .Index(t => t.LessonDataID)
                .Index(t => t.WorkItem_ID);
            
            CreateTable(
                "dbo.LessonDataModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Placeholder = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleInital = c.String(),
                        EmailAddress = c.String(),
                        LoginName = c.String(),
                        Password = c.String(),
                        PasswordShield = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GradeModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CurrentTotalGrade = c.Double(nullable: false),
                        StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StudentModels", t => t.StudentID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MyExtraProperty = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LessonModels", "WorkItem_ID", "dbo.WorkModels");
            DropForeignKey("dbo.LessonModels", "StudentID", "dbo.StudentModels");
            DropForeignKey("dbo.WorkModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.StudentModelCourseModels", "CourseModel_ID", "dbo.CourseModels");
            DropForeignKey("dbo.StudentModelCourseModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.GradeModels", "StudentID", "dbo.StudentModels");
            DropForeignKey("dbo.LessonModels", "LessonDataID", "dbo.LessonDataModels");
            DropForeignKey("dbo.LessonModels", "CourseID", "dbo.CourseModels");
            DropForeignKey("dbo.CourseModels", "InstructorID", "dbo.InstructorModels");
            DropForeignKey("dbo.WorkModels", "CourseModel_ID", "dbo.CourseModels");
            DropForeignKey("dbo.WorkModels", "QuestionsID", "dbo.QuestionstModels");
            DropForeignKey("dbo.WorkModels", "Answers_ID", "dbo.AnswerModels");
            DropIndex("dbo.StudentModelCourseModels", new[] { "CourseModel_ID" });
            DropIndex("dbo.StudentModelCourseModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.GradeModels", new[] { "StudentID" });
            DropIndex("dbo.LessonModels", new[] { "WorkItem_ID" });
            DropIndex("dbo.LessonModels", new[] { "LessonDataID" });
            DropIndex("dbo.LessonModels", new[] { "StudentID" });
            DropIndex("dbo.LessonModels", new[] { "CourseID" });
            DropIndex("dbo.WorkModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.WorkModels", new[] { "CourseModel_ID" });
            DropIndex("dbo.WorkModels", new[] { "Answers_ID" });
            DropIndex("dbo.WorkModels", new[] { "QuestionsID" });
            DropIndex("dbo.CourseModels", new[] { "InstructorID" });
            DropTable("dbo.StudentModelCourseModels");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.GradeModels");
            DropTable("dbo.StudentModels");
            DropTable("dbo.LessonDataModels");
            DropTable("dbo.LessonModels");
            DropTable("dbo.InstructorModels");
            DropTable("dbo.QuestionstModels");
            DropTable("dbo.WorkModels");
            DropTable("dbo.CourseModels");
            DropTable("dbo.AnswerModels");
            DropTable("dbo.AdminTableModels");
        }
    }
}
