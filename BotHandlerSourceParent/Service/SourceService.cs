using BotHandlerSourceParent.Constant;
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
            if (nodeList != null)
            {
                foreach (var node in nodeList)
                {
                    if (node.Attributes[VnExpress.HREF] != null)
                    {
                        var link = node.Attributes[VnExpress.HREF].Value;
                        if (string.IsNullOrEmpty(link) || link.Contains(VnExpress.BOX_COMMENT))
                        {
                            continue;
                        }

                        // Check urlSub đã có chưa nếu có rồi bỏ qua
                        var existSubUrl = articleService.CheckArticleByUrl(link);
                        if (existSubUrl)
                        {
                            continue;
                        }
                        EventQueue s = new(link, source);
                        eventQueues.Add(s);
                    }

                }
            }
            
            return eventQueues;
        }
    }
}
