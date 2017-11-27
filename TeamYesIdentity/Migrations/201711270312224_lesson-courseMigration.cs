namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lessoncourseMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LessonModels", "CourseID", "dbo.CourseModels");
            DropIndex("dbo.LessonModels", new[] { "CourseID" });
            CreateTable(
                "dbo.LessonModelCourseModels",
                c => new
                    {
                        LessonModel_ID = c.Int(nullable: false),
                        CourseModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LessonModel_ID, t.CourseModel_ID })
                .ForeignKey("dbo.LessonModels", t => t.LessonModel_ID, cascadeDelete: true)
                .ForeignKey("dbo.CourseModels", t => t.CourseModel_ID, cascadeDelete: true)
                .Index(t => t.LessonModel_ID)
                .Index(t => t.CourseModel_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LessonModelCourseModels", "CourseModel_ID", "dbo.CourseModels");
            DropForeignKey("dbo.LessonModelCourseModels", "LessonModel_ID", "dbo.LessonModels");
            DropIndex("dbo.LessonModelCourseModels", new[] { "CourseModel_ID" });
            DropIndex("dbo.LessonModelCourseModels", new[] { "LessonModel_ID" });
            DropTable("dbo.LessonModelCourseModels");
            CreateIndex("dbo.LessonModels", "CourseID");
            AddForeignKey("dbo.LessonModels", "CourseID", "dbo.CourseModels", "ID");
        }
    }
}
