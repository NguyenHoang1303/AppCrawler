using BotHandlerSourceParent.Entity;
using BotHandlerSourceParent.Queue;
using BotHandlerSourceParent.Repository;
using BotHandlerSourceParent.Service.IService;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace BotHandlerSourceParent.Service
{
    class SourceService : ISourceService
    {
        private ISourceRepository sourceRepository;
        private IArticleService articleService;
        public SourceService()
        {
            sourceRepository = new SourceRepository();
            articleService = new ArticleService();
        }

        public List<Source> GetAll()
        {
            return sourceRepository.GetAll();
        }

        public HashSet<EventQueue> GetSubLink(Source source)
        {
            var web = new HtmlWeb();
            HtmlDocument doc = web.Load(source.Url);
            var nodeList = doc.QuerySelectorAll(source.SelectorSubUrl);
            HashSet<EventQueue> eventQueues = new();
            foreach (var node in nodeList)
            {
                var link = node.Attributes["href"].Value;
                if (string.IsNullOrEmpty(link) || link.Contains("#box_comment_vne"))
                {
                    continue;
                }
                // Check urlSub đã có chưa nếu có rồi bỏ qua
                var existSubUrl = articleService.GetArticleByUrl(link);
                if (existSubUrl != null)
                {
                    continue;
                }
                Console.WriteLine(link);
                EventQueue s = new(link, source);
                eventQueues.Add(s);
            }
            return eventQueues;
        }
    }
}
