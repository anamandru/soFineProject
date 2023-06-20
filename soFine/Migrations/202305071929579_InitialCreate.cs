namespace soFine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HairProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        HairType = c.String(),
                        Category = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HairQuizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkinAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        SkinQuiz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SkinQuizs", t => t.SkinQuiz_Id)
                .Index(t => t.SkinQuiz_Id);
            
            CreateTable(
                "dbo.SkinProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        SkinType = c.String(),
                        Category = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkinQuizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpecialistAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CliniqueName = c.String(nullable: false),
                        University = c.String(nullable: false),
                        DiplomaNumber = c.String(nullable: false),
                        Validation = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        SkinType = c.String(),
                        HairType = c.String(),
                        HairQuiz_Id = c.Int(),
                        SkinQuiz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HairQuizs", t => t.HairQuiz_Id)
                .ForeignKey("dbo.SkinQuizs", t => t.SkinQuiz_Id)
                .Index(t => t.HairQuiz_Id)
                .Index(t => t.SkinQuiz_Id);
            
            CreateTable(
                "dbo.UsersHairProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.UsersSkinProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccounts", "SkinQuiz_Id", "dbo.SkinQuizs");
            DropForeignKey("dbo.UserAccounts", "HairQuiz_Id", "dbo.HairQuizs");
            DropForeignKey("dbo.SkinAnswers", "SkinQuiz_Id", "dbo.SkinQuizs");
            DropIndex("dbo.UserAccounts", new[] { "SkinQuiz_Id" });
            DropIndex("dbo.UserAccounts", new[] { "HairQuiz_Id" });
            DropIndex("dbo.SkinAnswers", new[] { "SkinQuiz_Id" });
            DropTable("dbo.UsersSkinProducts");
            DropTable("dbo.UsersSkinAnswers");
            DropTable("dbo.UsersHairProducts");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.SpecialistAccounts");
            DropTable("dbo.SkinQuizs");
            DropTable("dbo.SkinProducts");
            DropTable("dbo.SkinAnswers");
            DropTable("dbo.HairQuizs");
            DropTable("dbo.HairProducts");
        }
    }
}
