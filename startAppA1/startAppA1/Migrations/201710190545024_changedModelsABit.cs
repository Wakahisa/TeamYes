namespace startAppA1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedModelsABit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentModels", "CourseID", "dbo.CourseModels");
            DropIndex("dbo.StudentModels", new[] { "CourseID" });
            RenameColumn(table: "dbo.WorkModels", name: "CourseID", newName: "CourseModel_ID");
            RenameColumn(table: "dbo.WorkModels", name: "StudentID", newName: "StudentModel_ID");
            RenameIndex(table: "dbo.WorkModels", name: "IX_CourseID", newName: "IX_CourseModel_ID");
            RenameIndex(table: "dbo.WorkModels", name: "IX_StudentID", newName: "IX_StudentModel_ID");
            AddColumn("dbo.LessonModels", "NextLessonIDs", c => c.Int(nullable: false));
            AddColumn("dbo.LessonModels", "PreviousLessonIDs", c => c.Int(nullable: false));
            AddColumn("dbo.InstructorModels", "EmailAddress", c => c.String());
            DropColumn("dbo.StudentModels", "CourseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentModels", "CourseID", c => c.Int());
            DropColumn("dbo.InstructorModels", "EmailAddress");
            DropColumn("dbo.LessonModels", "PreviousLessonIDs");
            DropColumn("dbo.LessonModels", "NextLessonIDs");
            RenameIndex(table: "dbo.WorkModels", name: "IX_StudentModel_ID", newName: "IX_StudentID");
            RenameIndex(table: "dbo.WorkModels", name: "IX_CourseModel_ID", newName: "IX_CourseID");
            RenameColumn(table: "dbo.WorkModels", name: "StudentModel_ID", newName: "StudentID");
            RenameColumn(table: "dbo.WorkModels", name: "CourseModel_ID", newName: "CourseID");
            CreateIndex("dbo.StudentModels", "CourseID");
            AddForeignKey("dbo.StudentModels", "CourseID", "dbo.CourseModels", "ID");
        }
    }
}
