namespace soFine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "ArticleText", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "Author", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Author", c => c.String());
            AlterColumn("dbo.Articles", "ArticleText", c => c.String());
            AlterColumn("dbo.Articles", "Title", c => c.String());
        }
    }
}
