﻿namespace soFine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SkinAnswers", "SkinQuiz_Id1", "dbo.SkinQuizs");
            DropIndex("dbo.SkinAnswers", new[] { "SkinQuiz_Id1" });
            DropColumn("dbo.SkinAnswers", "SkinQuiz_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SkinAnswers", "SkinQuiz_Id1", c => c.Int());
            CreateIndex("dbo.SkinAnswers", "SkinQuiz_Id1");
            AddForeignKey("dbo.SkinAnswers", "SkinQuiz_Id1", "dbo.SkinQuizs", "Id");
        }
    }
}
