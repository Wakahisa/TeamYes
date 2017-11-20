namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilePathsRemoved : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.FilePaths");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId);
            
        }
    }
}
