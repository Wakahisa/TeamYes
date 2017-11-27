namespace TeamYesIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedQandAs : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.QuestionstModels", newName: "QuestionsModels");
            DropColumn("dbo.LessonModels", "CourseID");
            RenameColumn(table: "dbo.StringAnswers", name: "AnswerModel_ID", newName: "AmodelID");
            RenameColumn(table: "dbo.LessonModels", name: "CourseModel_ID", newName: "CourseID");
            RenameColumn(table: "dbo.StringQuestions", name: "QuestionstModel_ID", newName: "QmodelID");
            RenameIndex(table: "dbo.StringAnswers", name: "IX_AnswerModel_ID", newName: "IX_AmodelID");
            RenameIndex(table: "dbo.StringQuestions", name: "IX_QuestionstModel_ID", newName: "IX_QmodelID");
            RenameIndex(table: "dbo.LessonModels", name: "IX_CourseModel_ID", newName: "IX_CourseID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.LessonModels", name: "IX_CourseID", newName: "IX_CourseModel_ID");
            RenameIndex(table: "dbo.StringQuestions", name: "IX_QmodelID", newName: "IX_QuestionstModel_ID");
            RenameIndex(table: "dbo.StringAnswers", name: "IX_AmodelID", newName: "IX_AnswerModel_ID");
            RenameColumn(table: "dbo.StringQuestions", name: "QmodelID", newName: "QuestionstModel_ID");
            RenameColumn(table: "dbo.LessonModels", name: "CourseID", newName: "CourseModel_ID");
            RenameColumn(table: "dbo.StringAnswers", name: "AmodelID", newName: "AnswerModel_ID");
            AddColumn("dbo.LessonModels", "CourseID", c => c.Int());
            RenameTable(name: "dbo.QuestionsModels", newName: "QuestionstModels");
        }
    }
}
