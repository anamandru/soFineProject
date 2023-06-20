namespace soFine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HairAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        HairQuiz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HairQuizs", t => t.HairQuiz_Id)
                .Index(t => t.HairQuiz_Id);
            
            DropColumn("dbo.HairQuizs", "Answer");
            DropTable("dbo.UsersSkinAnswers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsersSkinAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkinQuizId = c.Int(nullable: false),
                        SkinAnswerId = c.Int(nullable: false),
                        UserAccountId = c.Int(nullable: false),
                        IsSelected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.HairQuizs", "Answer", c => c.String());
            DropForeignKey("dbo.HairAnswers", "HairQuiz_Id", "dbo.HairQuizs");
            DropIndex("dbo.HairAnswers", new[] { "HairQuiz_Id" });
            DropTable("dbo.HairAnswers");
        }
    }
}
