using BotHandlerSourceParent.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceParent.Repository.IRepo
{
    interface IArticleRepository
    {
        List<Article> GetAll();
        Article GetArticleByUrl(string urlSource);
    }
}
