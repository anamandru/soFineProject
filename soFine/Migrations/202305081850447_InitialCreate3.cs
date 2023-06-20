namespace soFine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SkinAnswers", "SkinQuiz_Id", c => c.Int());
            CreateIndex("dbo.SkinAnswers", "SkinQuiz_Id");
            AddForeignKey("dbo.SkinAnswers", "SkinQuiz_Id", "dbo.SkinQuizs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkinAnswers", "SkinQuiz_Id", "dbo.SkinQuizs");
            DropIndex("dbo.SkinAnswers", new[] { "SkinQuiz_Id" });
            AlterColumn("dbo.SkinAnswers", "SkinQuiz_Id", c => c.Int(nullable: false));
        }
    }
}
