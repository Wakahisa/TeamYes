namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDiscriminator : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AppUsers", newName: "ApplicationUsers");
            RenameColumn(table: "dbo.IdentityUserClaims", name: "AppUser_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.IdentityUserLogins", name: "AppUser_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.IdentityUserRoles", name: "AppUser_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.IdentityUserRoles", name: "IX_AppUser_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.IdentityUserClaims", name: "IX_AppUser_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.IdentityUserLogins", name: "IX_AppUser_Id", newName: "IX_ApplicationUser_Id");
            DropColumn("dbo.IdentityRoles", "Discriminator");
            DropColumn("dbo.ApplicationUsers", "MyExtraProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUsers", "MyExtraProperty", c => c.String());
            AddColumn("dbo.IdentityRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            RenameIndex(table: "dbo.IdentityUserLogins", name: "IX_ApplicationUser_Id", newName: "IX_AppUser_Id");
            RenameIndex(table: "dbo.IdentityUserClaims", name: "IX_ApplicationUser_Id", newName: "IX_AppUser_Id");
            RenameIndex(table: "dbo.IdentityUserRoles", name: "IX_ApplicationUser_Id", newName: "IX_AppUser_Id");
            RenameColumn(table: "dbo.IdentityUserRoles", name: "ApplicationUser_Id", newName: "AppUser_Id");
            RenameColumn(table: "dbo.IdentityUserLogins", name: "ApplicationUser_Id", newName: "AppUser_Id");
            RenameColumn(table: "dbo.IdentityUserClaims", name: "ApplicationUser_Id", newName: "AppUser_Id");
            RenameTable(name: "dbo.ApplicationUsers", newName: "AppUsers");
        }
    }
}
