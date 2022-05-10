using BotHandlerSourceSub.Constant;
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
        private HtmlDocument doc;
        private readonly HtmlWeb web;

        public ArticleService()
        {
            articleRepository = new ArticleRepository();
            web = new HtmlWeb();
        }

        public Article GetArticle(EventQueue eventQueue)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            doc = web.Load(eventQueue.Url);
            var title = doc.QuerySelector(eventQueue.SelectorTitle)?.InnerText;
            var description = doc.QuerySelector(eventQueue.SelectorDescrition)?.InnerText;
            var image = doc.QuerySelector(eventQueue.SelectorImage)?.GetAttributeValue(VnExpress.DATA_SRC, null);
            var contentNode = GetValueAllSelector(eventQueue.SelectorContent);

            Article article = new()
            {
               
                UrlSource = eventQueue.Url,
                Title = title,
                Image = image,
                Description = description,
                CategoryId = eventQueue.CategryId,
                Content = contentNode,
                
                
            };
            if (!article.Validation())
            {
                return null;
            }
            return article;

        }

        public Article Save(Article article)
        {
            return articleRepository.Save(article);
        }

        public string GetValueAllSelector(string selector) 
        {
            var listSelector = doc.QuerySelectorAll(selector);
            StringBuilder contentBuilder = new();
            if (listSelector != null || listSelector.Count > 0)
            {
                foreach (var content in listSelector)
                {
                    contentBuilder.Append(content.InnerHtml);
                }
                return contentBuilder.ToString();
            }
            return null;
        }

        public bool CheckArticleByUrl(string url)
        {
            return articleRepository.CheckArticleByUrl(url);
        }
    }
}
