namespace startAppA1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentModels", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentModels", "EmailAddress");
        }
    }
}
