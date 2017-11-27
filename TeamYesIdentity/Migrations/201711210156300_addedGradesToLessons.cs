namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedGradesToLessons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LessonModelGradeModels",
                c => new
                    {
                        LessonModel_ID = c.Int(nullable: false),
                        GradeModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LessonModel_ID, t.GradeModel_ID })
                .ForeignKey("dbo.LessonModels", t => t.LessonModel_ID, cascadeDelete: true)
                .ForeignKey("dbo.GradeModels", t => t.GradeModel_ID, cascadeDelete: true)
                .Index(t => t.LessonModel_ID)
                .Index(t => t.GradeModel_ID);
            
            AddColumn("dbo.LessonModels", "GradeID", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LessonModelGradeModels", "GradeModel_ID", "dbo.GradeModels");
            DropForeignKey("dbo.LessonModelGradeModels", "LessonModel_ID", "dbo.LessonModels");
            DropIndex("dbo.LessonModelGradeModels", new[] { "GradeModel_ID" });
            DropIndex("dbo.LessonModelGradeModels", new[] { "LessonModel_ID" });
            DropColumn("dbo.LessonModels", "GradeID");
            DropTable("dbo.LessonModelGradeModels");
        }
    }
}
