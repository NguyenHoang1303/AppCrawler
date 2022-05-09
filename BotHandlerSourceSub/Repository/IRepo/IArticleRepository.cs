using BotHandlerSourceSub.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceSub.Repository.IRepo
{
    interface IArticleRepository
    {
        Article Save(Article article);
        List<Article> GetAll();
        bool CheckArticleByUrl(string urlSource);
    }
}
