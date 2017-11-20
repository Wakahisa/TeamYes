namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastTestForManyToMany : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.FooModelBooModels", "FooModel_ID", "dbo.FooModels");
            //DropForeignKey("dbo.FooModelBooModels", "BooModel_ID", "dbo.BooModels");
            //DropForeignKey("dbo.GooModelBooModels", "GooModel_ID", "dbo.GooModels");
            //DropForeignKey("dbo.GooModelBooModels", "BooModel_ID", "dbo.BooModels");
            //DropForeignKey("dbo.GooModels", "GooModel_ID", "dbo.GooModels");
            //DropForeignKey("dbo.GooModels", "FooModel_ID", "dbo.FooModels");
            //DropIndex("dbo.GooModels", new[] { "GooModel_ID" });
            //DropIndex("dbo.GooModels", new[] { "FooModel_ID" });
            //DropIndex("dbo.FooModelBooModels", new[] { "FooModel_ID" });
            //DropIndex("dbo.FooModelBooModels", new[] { "BooModel_ID" });
            //DropIndex("dbo.GooModelBooModels", new[] { "GooModel_ID" });
            //DropIndex("dbo.GooModelBooModels", new[] { "BooModel_ID" });
            //DropTable("dbo.BooModels");
            //DropTable("dbo.FooModels");
            //DropTable("dbo.GooModels");
            //DropTable("dbo.FooModelBooModels");
            //DropTable("dbo.GooModelBooModels");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.GooModelBooModels",
            //    c => new
            //        {
            //            GooModel_ID = c.Int(nullable: false),
            //            BooModel_ID = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.GooModel_ID, t.BooModel_ID });
            
            //CreateTable(
            //    "dbo.FooModelBooModels",
            //    c => new
            //        {
            //            FooModel_ID = c.Int(nullable: false),
            //            BooModel_ID = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.FooModel_ID, t.BooModel_ID });
            
            //CreateTable(
            //    "dbo.GooModels",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            GooModel_ID = c.Int(),
            //            FooModel_ID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.FooModels",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.BooModels",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateIndex("dbo.GooModelBooModels", "BooModel_ID");
            //CreateIndex("dbo.GooModelBooModels", "GooModel_ID");
            //CreateIndex("dbo.FooModelBooModels", "BooModel_ID");
            //CreateIndex("dbo.FooModelBooModels", "FooModel_ID");
            //CreateIndex("dbo.GooModels", "FooModel_ID");
            //CreateIndex("dbo.GooModels", "GooModel_ID");
            //AddForeignKey("dbo.GooModels", "FooModel_ID", "dbo.FooModels", "ID");
            //AddForeignKey("dbo.GooModels", "GooModel_ID", "dbo.GooModels", "ID");
            //AddForeignKey("dbo.GooModelBooModels", "BooModel_ID", "dbo.BooModels", "ID", cascadeDelete: true);
            //AddForeignKey("dbo.GooModelBooModels", "GooModel_ID", "dbo.GooModels", "ID", cascadeDelete: true);
            //AddForeignKey("dbo.FooModelBooModels", "BooModel_ID", "dbo.BooModels", "ID", cascadeDelete: true);
            //AddForeignKey("dbo.FooModelBooModels", "FooModel_ID", "dbo.FooModels", "ID", cascadeDelete: true);
        }
    }
}
