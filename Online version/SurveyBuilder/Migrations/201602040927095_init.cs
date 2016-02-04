namespace SurveyBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SurveyQuestions",
                c => new
                    {
                        SurveyQuestionId = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        MutuallyExclusiveOptions = c.Boolean(nullable: false),
                        Required = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Survey_SurveyId = c.Int(),
                    })
                .PrimaryKey(t => t.SurveyQuestionId)
                .ForeignKey("dbo.Surveys", t => t.Survey_SurveyId)
                .Index(t => t.Survey_SurveyId);
            
            CreateTable(
                "dbo.MultipleChoiceOptions",
                c => new
                    {
                        MultipleChoiceOptionID = c.Int(nullable: false, identity: true),
                        Option = c.String(),
                        SurveyQuestion_SurveyQuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.MultipleChoiceOptionID)
                .ForeignKey("dbo.SurveyQuestions", t => t.SurveyQuestion_SurveyQuestionId)
                .Index(t => t.SurveyQuestion_SurveyQuestionId);
            
            CreateTable(
                "dbo.SurveyResponses",
                c => new
                    {
                        SurveyResponseId = c.Int(nullable: false, identity: true),
                        SurveyId = c.Int(nullable: false),
                        Response = c.String(),
                        SurveyQuestionId = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.SurveyResponseId)
                .ForeignKey("dbo.Surveys", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        SurveyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CompletionMessage = c.String(),
                        IsClosed = c.Boolean(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.SurveyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurveyResponses", "SurveyId", "dbo.Surveys");
            DropForeignKey("dbo.SurveyQuestions", "Survey_SurveyId", "dbo.Surveys");
            DropForeignKey("dbo.MultipleChoiceOptions", "SurveyQuestion_SurveyQuestionId", "dbo.SurveyQuestions");
            DropIndex("dbo.SurveyResponses", new[] { "SurveyId" });
            DropIndex("dbo.MultipleChoiceOptions", new[] { "SurveyQuestion_SurveyQuestionId" });
            DropIndex("dbo.SurveyQuestions", new[] { "Survey_SurveyId" });
            DropTable("dbo.Surveys");
            DropTable("dbo.SurveyResponses");
            DropTable("dbo.MultipleChoiceOptions");
            DropTable("dbo.SurveyQuestions");
        }
    }
}
