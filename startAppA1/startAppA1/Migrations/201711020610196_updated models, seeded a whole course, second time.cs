namespace startAppA1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodelsseededawholecoursesecondtime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LessonModels", "OpenAtTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.LessonModels", "CloseAtTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.LessonModels", "TimeLimit", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LessonModels", "TimeLimit", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LessonModels", "CloseAtTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LessonModels", "OpenAtTime", c => c.DateTime(nullable: false));
        }
    }
}
