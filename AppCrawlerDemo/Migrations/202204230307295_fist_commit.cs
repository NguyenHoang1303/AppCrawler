namespace AppCrawlerDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fist_commit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article",
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
                "dbo.Category",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Source",
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
            DropTable("dbo.Source");
            DropTable("dbo.Category");
            DropTable("dbo.Article");
        }
    }
}
