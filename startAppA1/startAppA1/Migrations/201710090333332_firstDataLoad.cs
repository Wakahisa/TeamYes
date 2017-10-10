namespace startAppA1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstDataLoad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminTableModels",
                c => new
                    {
                        TableID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TableID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminTableModels");
        }
    }
}
