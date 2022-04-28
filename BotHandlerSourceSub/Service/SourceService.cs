using BotHandlerSourceSub.Entity;
using BotHandlerSourceSub.Queue;
using BotHandlerSourceSub.Repository;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace BotHandlerSourceSub.Service
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

    }
}
