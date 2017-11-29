namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Containsalloldermigrations : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "IdentityRoles");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "IdentityUserRoles");
            RenameTable(name: "dbo.AspNetUsers", newName: "AppUsers");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "IdentityUserClaims");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "IdentityUserLogins");
            DropForeignKey("dbo.WorkModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.LessonModels", "StudentID", "dbo.StudentModels");
            DropForeignKey("dbo.CourseModels", "InstructorID", "dbo.InstructorModels");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.WorkModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.LessonModels", new[] { "StudentID" });
            DropIndex("dbo.IdentityRoles", "RoleNameIndex");
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AppUsers", "UserNameIndex");
            DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "UserId" });
            DropPrimaryKey("dbo.IdentityUserRoles");
            DropPrimaryKey("dbo.IdentityUserLogins");
            CreateTable(
                "dbo.StringAnswerModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        AnswerModelID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.QuestionsModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StringQuestionModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        QuestionModelID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StringAnswerModelAnswerModels",
                c => new
                    {
                        StringAnswerModel_ID = c.Int(nullable: false),
                        AnswerModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StringAnswerModel_ID, t.AnswerModel_ID })
                .ForeignKey("dbo.StringAnswerModels", t => t.StringAnswerModel_ID, cascadeDelete: true)
                .ForeignKey("dbo.AnswerModels", t => t.AnswerModel_ID, cascadeDelete: true)
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
                .ForeignKey("dbo.QuestionsModels", t => t.QuestionsModel_ID, cascadeDelete: true)
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
                .ForeignKey("dbo.WorkModels", t => t.WorkModel_ID, cascadeDelete: true)
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
                .ForeignKey("dbo.StudentModels", t => t.StudentModel_ID, cascadeDelete: true)
                .Index(t => t.LessonModel_ID)
                .Index(t => t.StudentModel_ID);
            
            AddColumn("dbo.CourseModels", "InstructorModel_ID", c => c.Int());
            AddColumn("dbo.InstructorModels", "CourseModel_ID", c => c.Int());
            AddColumn("dbo.IdentityUserRoles", "IdentityRole_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserRoles", "AppUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserClaims", "AppUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserLogins", "AppUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.IdentityRoles", "Name", c => c.String());
            AlterColumn("dbo.AppUsers", "Email", c => c.String());
            AlterColumn("dbo.AppUsers", "UserName", c => c.String());
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String());
            AlterColumn("dbo.IdentityUserLogins", "LoginProvider", c => c.String());
            AlterColumn("dbo.IdentityUserLogins", "ProviderKey", c => c.String());
            AddPrimaryKey("dbo.IdentityUserRoles", new[] { "RoleId", "UserId" });
            AddPrimaryKey("dbo.IdentityUserLogins", "UserId");
            CreateIndex("dbo.CourseModels", "InstructorModel_ID");
            CreateIndex("dbo.InstructorModels", "CourseModel_ID");
            CreateIndex("dbo.IdentityUserRoles", "IdentityRole_Id");
            CreateIndex("dbo.IdentityUserRoles", "AppUser_Id");
            CreateIndex("dbo.IdentityUserClaims", "AppUser_Id");
            CreateIndex("dbo.IdentityUserLogins", "AppUser_Id");
            AddForeignKey("dbo.InstructorModels", "CourseModel_ID", "dbo.CourseModels", "ID");
            AddForeignKey("dbo.CourseModels", "InstructorModel_ID", "dbo.InstructorModels", "ID");
            AddForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles", "Id");
            AddForeignKey("dbo.IdentityUserClaims", "AppUser_Id", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.IdentityUserLogins", "AppUser_Id", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.IdentityUserRoles", "AppUser_Id", "dbo.AppUsers", "Id");
            DropColumn("dbo.WorkModels", "StudentModel_ID");
            DropColumn("dbo.LessonModels", "StudentID");
            DropTable("dbo.QuestionstModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QuestionstModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.LessonModels", "StudentID", c => c.Int());
            AddColumn("dbo.WorkModels", "StudentModel_ID", c => c.Int());
            DropForeignKey("dbo.IdentityUserRoles", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.IdentityUserLogins", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.IdentityUserClaims", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
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
            DropIndex("dbo.IdentityUserLogins", new[] { "AppUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "AppUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "AppUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.InstructorModels", new[] { "CourseModel_ID" });
            DropIndex("dbo.CourseModels", new[] { "InstructorModel_ID" });
            DropPrimaryKey("dbo.IdentityUserLogins");
            DropPrimaryKey("dbo.IdentityUserRoles");
            AlterColumn("dbo.IdentityUserLogins", "ProviderKey", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserLogins", "LoginProvider", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AppUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AppUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.IdentityRoles", "Name", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.IdentityUserLogins", "AppUser_Id");
            DropColumn("dbo.IdentityUserClaims", "AppUser_Id");
            DropColumn("dbo.IdentityUserRoles", "AppUser_Id");
            DropColumn("dbo.IdentityUserRoles", "IdentityRole_Id");
            DropColumn("dbo.InstructorModels", "CourseModel_ID");
            DropColumn("dbo.CourseModels", "InstructorModel_ID");
            DropTable("dbo.LessonModelStudentModels");
            DropTable("dbo.StudentModelWorkModels");
            DropTable("dbo.StringQuestionModelQuestionsModels");
            DropTable("dbo.StringAnswerModelAnswerModels");
            DropTable("dbo.StringQuestionModels");
            DropTable("dbo.QuestionsModels");
            DropTable("dbo.StringAnswerModels");
            AddPrimaryKey("dbo.IdentityUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            AddPrimaryKey("dbo.IdentityUserRoles", new[] { "UserId", "RoleId" });
            CreateIndex("dbo.IdentityUserLogins", "UserId");
            CreateIndex("dbo.IdentityUserClaims", "UserId");
            CreateIndex("dbo.AppUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.IdentityUserRoles", "RoleId");
            CreateIndex("dbo.IdentityUserRoles", "UserId");
            CreateIndex("dbo.IdentityRoles", "Name", unique: true, name: "RoleNameIndex");
            CreateIndex("dbo.LessonModels", "StudentID");
            CreateIndex("dbo.WorkModels", "StudentModel_ID");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseModels", "InstructorID", "dbo.InstructorModels", "ID");
            AddForeignKey("dbo.LessonModels", "StudentID", "dbo.StudentModels", "ID");
            AddForeignKey("dbo.WorkModels", "StudentModel_ID", "dbo.StudentModels", "ID");
            RenameTable(name: "dbo.IdentityUserLogins", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.IdentityUserClaims", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.AppUsers", newName: "AspNetUsers");
            RenameTable(name: "dbo.IdentityUserRoles", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.IdentityRoles", newName: "AspNetRoles");
        }
    }
}
