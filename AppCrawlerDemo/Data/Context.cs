using AppCrawlerDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AppCrawlerDemo.Data
{
    public class Context: DbContext
    {
        public Context() : base("DbArticle")
        {
        }
        public DbSet<Article> Article { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}