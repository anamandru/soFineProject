namespace soFine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "AnsweredBy", c => c.String());
            DropColumn("dbo.Questions", "IdSpecialist");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "IdSpecialist", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "AnsweredBy");
        }
    }
}
