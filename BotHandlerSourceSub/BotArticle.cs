using BotHandlerSourceSub.Queue;
using BotHandlerSourceSub.Service;
using BotHandlerSourceSub.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceSub
{
    class BotArticle
    {
        private MyQueue myQueue;
        private IArticleService articleService;
        public BotArticle()
        {
            myQueue = new MyQueue();
            articleService = new ArticleService();
        }

        public void Start()
        {
            articleService.GetArticle(new EventQueue());
        }
    }
}
