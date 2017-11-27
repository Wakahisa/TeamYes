namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixing_questions_and_answers1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LessonModels", "CourseID", "dbo.CourseModels");
            DropIndex("dbo.LessonModels", new[] { "CourseID" });
            AddColumn("dbo.LessonModels", "CourseModel_ID", c => c.Int());
            CreateIndex("dbo.LessonModels", "CourseModel_ID");
            AddForeignKey("dbo.LessonModels", "CourseModel_ID", "dbo.CourseModels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LessonModels", "CourseModel_ID", "dbo.CourseModels");
            DropIndex("dbo.LessonModels", new[] { "CourseModel_ID" });
            DropColumn("dbo.LessonModels", "CourseModel_ID");
            CreateIndex("dbo.LessonModels", "CourseID");
            AddForeignKey("dbo.LessonModels", "CourseID", "dbo.CourseModels", "ID");
        }
    }
}
