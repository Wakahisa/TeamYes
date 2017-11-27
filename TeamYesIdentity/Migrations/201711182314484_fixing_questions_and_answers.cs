namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixing_questions_and_answers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StringAnswers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        AnswerModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AnswerModels", t => t.AnswerModel_ID)
                .Index(t => t.AnswerModel_ID);
            
            CreateTable(
                "dbo.StringQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        QuestionsModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuestionsModels", t => t.QuestionsModel_ID)
                .Index(t => t.QuestionsModel_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StringQuestions", "QuestionsModel_ID", "dbo.QuestionsModels");
            DropForeignKey("dbo.StringAnswers", "AnswerModel_ID", "dbo.AnswerModels");
            DropIndex("dbo.StringQuestions", new[] { "QuestionsModel_ID" });
            DropIndex("dbo.StringAnswers", new[] { "AnswerModel_ID" });
            DropTable("dbo.StringQuestions");
            DropTable("dbo.StringAnswers");
        }
    }
}
