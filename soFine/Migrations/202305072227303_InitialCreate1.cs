namespace soFine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SkinAnswers", "SkinQuiz_Id", "dbo.SkinQuizs");
            DropIndex("dbo.SkinAnswers", new[] { "SkinQuiz_Id" });
            AddColumn("dbo.SkinAnswers", "SkinQuiz_Id1", c => c.Int());
            AlterColumn("dbo.SkinAnswers", "SkinQuiz_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.SkinAnswers", "SkinQuiz_Id1");
            AddForeignKey("dbo.SkinAnswers", "SkinQuiz_Id1", "dbo.SkinQuizs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkinAnswers", "SkinQuiz_Id1", "dbo.SkinQuizs");
            DropIndex("dbo.SkinAnswers", new[] { "SkinQuiz_Id1" });
            AlterColumn("dbo.SkinAnswers", "SkinQuiz_Id", c => c.Int());
            DropColumn("dbo.SkinAnswers", "SkinQuiz_Id1");
            CreateIndex("dbo.SkinAnswers", "SkinQuiz_Id");
            AddForeignKey("dbo.SkinAnswers", "SkinQuiz_Id", "dbo.SkinQuizs", "Id");
        }
    }
}
