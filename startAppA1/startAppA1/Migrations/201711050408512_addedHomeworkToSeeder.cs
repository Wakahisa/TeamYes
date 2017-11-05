namespace startAppA1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedHomeworkToSeeder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkModels", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkModels", "Title");
        }
    }
}
