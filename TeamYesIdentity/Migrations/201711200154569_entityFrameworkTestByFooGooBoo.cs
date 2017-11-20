namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entityFrameworkTestByFooGooBoo : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StringAnswers", newName: "StringAnswerModels");
            RenameTable(name: "dbo.StringQuestions", newName: "StringQuestionModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.StringQuestionModels", newName: "StringQuestions");
            RenameTable(name: "dbo.StringAnswerModels", newName: "StringAnswers");
        }
    }
}
