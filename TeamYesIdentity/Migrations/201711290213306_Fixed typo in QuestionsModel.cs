namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedtypoinQuestionsModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.QuestionstModels", newName: "QuestionsModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.QuestionsModels", newName: "QuestionstModels");
        }
    }
}
