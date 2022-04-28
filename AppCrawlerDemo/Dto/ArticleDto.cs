using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppCrawlerDemo.Dto
{
    public class ArticleDto
    {
        public string UrlSource { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string CategoryName { get; set; }
        public bool IsDeleted { get; set; } = true;
        public long CreatedAt { get; set; }
    }
}