using BotHandlerSourceSub.Entity;
using BotHandlerSourceSub.Queue;
using BotHandlerSourceSub.Repository;
using BotHandlerSourceSub.Repository.IRepo;
using BotHandlerSourceSub.Service.IService;
using HtmlAgilityPack;
using System;
using System.Text;

namespace BotHandlerSourceSub.Service
{
    class ArticleService : IArticleService
    {
        private IArticleRepository articleRepository;

        public ArticleService()
        {
            articleRepository = new ArticleRepository();
        }

        public Article GetArticle(EventQueue eventQueue)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                var web = new HtmlWeb();
                HtmlDocument doc = web.Load(eventQueue.Url);
                var title = doc.QuerySelector(eventQueue.SelectorTitle).InnerText;
                var description = doc.QuerySelector(eventQueue.SelectorDescrition).InnerText;
                var imageNode = doc.QuerySelector(eventQueue.SelectorImage);
                string image = "";
                if(imageNode != null)
                {
                    image = imageNode.GetAttributeValue("data-src", string.Empty);
                }
                var contentNode = doc.QuerySelectorAll(eventQueue.SelectorContent);
                StringBuilder contentBuilder = new StringBuilder();
                foreach (var content in contentNode)
                {
                    contentBuilder.Append(content.InnerHtml);
                }

                Article article = new ()
                {
                    UrlSource = eventQueue.Url,
                    Title = title,
                    Image = image.ToString(),
                    Description = description,
                    CategoryId = eventQueue.CategryId,
                    Content = contentBuilder.ToString()
                };
                return article;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Article Save(Article article)
        {
            return articleRepository.Save(article);
        }

     
    }
}
