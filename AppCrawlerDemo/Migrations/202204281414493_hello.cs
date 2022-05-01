namespace AppCrawlerDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hello : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        UrlSource = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        CategoryId = c.String(),
                        CreatedAt = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.UrlSource);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Url = c.String(),
                        SelectorSubUrl = c.String(),
                        SelectorTitle = c.String(),
                        SelectorImage = c.String(),
                        SelectorDescrition = c.String(),
                        SelectorContent = c.String(),
                        CategoryId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sources");
            DropTable("dbo.Categories");
            DropTable("dbo.Articles");
        }
    }
}
