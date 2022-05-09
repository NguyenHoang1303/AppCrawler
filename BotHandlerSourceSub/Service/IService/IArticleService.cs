using BotHandlerSourceSub.Entity;
using BotHandlerSourceSub.Queue;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceSub.Service.IService
{
    interface IArticleService
    {
        Article Save(Article article);
        Article GetArticle(EventQueue eventQueue);

        bool CheckArticleByUrl(string url);
    }
}
