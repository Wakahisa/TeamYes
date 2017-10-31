namespace startAppA1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModels3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentModelCourseModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.StudentModelCourseModels", "CourseModel_ID", "dbo.CourseModels");
            DropIndex("dbo.StudentModelCourseModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.StudentModelCourseModels", new[] { "CourseModel_ID" });
            RenameColumn(table: "dbo.WorkModels", name: "CourseModel_ID", newName: "CourseID");
            RenameColumn(table: "dbo.LessonModels", name: "CourseModel_ID", newName: "CourseID");
            RenameColumn(table: "dbo.GradeModels", name: "StudentModel_ID", newName: "StudentID");
            RenameColumn(table: "dbo.WorkModels", name: "StudentModel_ID", newName: "StudentID");
            RenameColumn(table: "dbo.LessonModels", name: "StudentModel_ID", newName: "StudentID");
            RenameColumn(table: "dbo.CourseModels", name: "InstructorModel_ID", newName: "InstructorID");
            RenameIndex(table: "dbo.CourseModels", name: "IX_InstructorModel_ID", newName: "IX_InstructorID");
            RenameIndex(table: "dbo.WorkModels", name: "IX_CourseModel_ID", newName: "IX_CourseID");
            RenameIndex(table: "dbo.WorkModels", name: "IX_StudentModel_ID", newName: "IX_StudentID");
            RenameIndex(table: "dbo.GradeModels", name: "IX_StudentModel_ID", newName: "IX_StudentID");
            RenameIndex(table: "dbo.LessonModels", name: "IX_CourseModel_ID", newName: "IX_CourseID");
            RenameIndex(table: "dbo.LessonModels", name: "IX_StudentModel_ID", newName: "IX_StudentID");
            AddColumn("dbo.CourseModels", "StudentID", c => c.Int());
            AddColumn("dbo.CourseModels", "StudentModel_ID", c => c.Int());
            AddColumn("dbo.StudentModels", "CourseID", c => c.Int());
            AddColumn("dbo.StudentModels", "CourseModel_ID", c => c.Int());
            CreateIndex("dbo.CourseModels", "StudentID");
            CreateIndex("dbo.CourseModels", "StudentModel_ID");
            CreateIndex("dbo.StudentModels", "CourseID");
            CreateIndex("dbo.StudentModels", "CourseModel_ID");
            AddForeignKey("dbo.StudentModels", "CourseID", "dbo.CourseModels", "ID");
            AddForeignKey("dbo.CourseModels", "StudentModel_ID", "dbo.StudentModels", "ID");
            AddForeignKey("dbo.CourseModels", "StudentID", "dbo.StudentModels", "ID");
            AddForeignKey("dbo.StudentModels", "CourseModel_ID", "dbo.CourseModels", "ID");
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
            
            DropForeignKey("dbo.StudentModels", "CourseModel_ID", "dbo.CourseModels");
            DropForeignKey("dbo.CourseModels", "StudentID", "dbo.StudentModels");
            DropForeignKey("dbo.CourseModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.StudentModels", "CourseID", "dbo.CourseModels");
            DropIndex("dbo.StudentModels", new[] { "CourseModel_ID" });
            DropIndex("dbo.StudentModels", new[] { "CourseID" });
            DropIndex("dbo.CourseModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.CourseModels", new[] { "StudentID" });
            DropColumn("dbo.StudentModels", "CourseModel_ID");
            DropColumn("dbo.StudentModels", "CourseID");
            DropColumn("dbo.CourseModels", "StudentModel_ID");
            DropColumn("dbo.CourseModels", "StudentID");
            RenameIndex(table: "dbo.LessonModels", name: "IX_StudentID", newName: "IX_StudentModel_ID");
            RenameIndex(table: "dbo.LessonModels", name: "IX_CourseID", newName: "IX_CourseModel_ID");
            RenameIndex(table: "dbo.GradeModels", name: "IX_StudentID", newName: "IX_StudentModel_ID");
            RenameIndex(table: "dbo.WorkModels", name: "IX_StudentID", newName: "IX_StudentModel_ID");
            RenameIndex(table: "dbo.WorkModels", name: "IX_CourseID", newName: "IX_CourseModel_ID");
            RenameIndex(table: "dbo.CourseModels", name: "IX_InstructorID", newName: "IX_InstructorModel_ID");
            RenameColumn(table: "dbo.CourseModels", name: "InstructorID", newName: "InstructorModel_ID");
            RenameColumn(table: "dbo.LessonModels", name: "StudentID", newName: "StudentModel_ID");
            RenameColumn(table: "dbo.WorkModels", name: "StudentID", newName: "StudentModel_ID");
            RenameColumn(table: "dbo.GradeModels", name: "StudentID", newName: "StudentModel_ID");
            RenameColumn(table: "dbo.LessonModels", name: "CourseID", newName: "CourseModel_ID");
            RenameColumn(table: "dbo.WorkModels", name: "CourseID", newName: "CourseModel_ID");
            CreateIndex("dbo.StudentModelCourseModels", "CourseModel_ID");
            CreateIndex("dbo.StudentModelCourseModels", "StudentModel_ID");
            AddForeignKey("dbo.StudentModelCourseModels", "CourseModel_ID", "dbo.CourseModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StudentModelCourseModels", "StudentModel_ID", "dbo.StudentModels", "ID", cascadeDelete: true);
        }
    }
}
