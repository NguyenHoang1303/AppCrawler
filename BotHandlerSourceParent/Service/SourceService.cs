using BotHandlerSourceParent.Entity;
using BotHandlerSourceParent.Queue;
using BotHandlerSourceParent.Repository;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace BotHandlerSourceParent.Service
{
    class SourceService : ISourceService
    {
        private SourceRepository sourceRepository;
        private ArticleRepository articleRepository;
        public SourceService()
        {
            sourceRepository = new SourceRepository();
            articleRepository = new ArticleRepository();
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
            int number = 0;
            foreach (var node in nodeList)
            {
                var link = node.Attributes["href"].Value;
                if (string.IsNullOrEmpty(link) || link.Contains("#box_comment_vne"))
                {
                    continue;
                }
                // Check urlSub đã có chưa nếu có rồi bỏ qua
                var existSubUrl = articleRepository.GetArticleByUrl(link);
                if (existSubUrl != null)
                {
                    continue;
                }
                number++;
                EventQueue s = new(link, source);
                eventQueues.Add(s);
            }
            return eventQueues;
        }
    }
}
