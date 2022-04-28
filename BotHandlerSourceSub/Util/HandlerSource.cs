using BotHandlerSourceSub.Entity;
using BotHandlerSourceSub.Queue;
using BotHandlerSourceSub.Repository;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceSub.Util
{
    class HandlerSource
    {

        public static void GetArticle() 
        {

            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                var web = new HtmlWeb();
                var url = "https://vnexpress.net/verstappen-thang-ap-dao-tren-san-nha-ferrari-4455452.html";
                HtmlDocument doc = web.Load(url);
                var title = doc.QuerySelector("h1.title-detail").InnerText;
                var imageNode = doc.QuerySelector("article.fck_detail img");
                var image = imageNode.Attributes["data-src"].Value;
                var contentNode = doc.QuerySelector("article.fck_detail");
                Article article = new Article()
                {
                    UrlSource = url,
                    Title = title,
                    Image = image,
                    Content = contentNode.ToString()
                };
                Console.WriteLine("image: " + image);
                Console.WriteLine("title: " + title);
                Console.WriteLine("content: " + contentNode.InnerText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
        }

    }
}
