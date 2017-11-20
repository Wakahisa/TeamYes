namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yesResetLists : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.WorkModels", "CourseModel_ID", c => c.Int());
            AddColumn("dbo.WorkModels", "StudentModel_ID", c => c.Int());
            CreateIndex("dbo.WorkModels", "CourseModel_ID");
            CreateIndex("dbo.WorkModels", "StudentModel_ID");
            AddForeignKey("dbo.WorkModels", "CourseModel_ID", "dbo.CourseModels", "ID");
            AddForeignKey("dbo.WorkModels", "StudentModel_ID", "dbo.StudentModels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.StudentModelCourseModels", "CourseModel_ID", "dbo.CourseModels");
            DropForeignKey("dbo.StudentModelCourseModels", "StudentModel_ID", "dbo.StudentModels");
            DropForeignKey("dbo.WorkModels", "CourseModel_ID", "dbo.CourseModels");
            DropIndex("dbo.StudentModelCourseModels", new[] { "CourseModel_ID" });
            DropIndex("dbo.StudentModelCourseModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.WorkModels", new[] { "StudentModel_ID" });
            DropIndex("dbo.WorkModels", new[] { "CourseModel_ID" });
            DropColumn("dbo.WorkModels", "StudentModel_ID");
            DropColumn("dbo.WorkModels", "CourseModel_ID");
            DropTable("dbo.StudentModelCourseModels");
        }
    }
}
