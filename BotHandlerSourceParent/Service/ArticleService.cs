using BotHandlerSourceParent.Entity;
using BotHandlerSourceParent.Repository;
using BotHandlerSourceParent.Repository.IRepo;
using BotHandlerSourceParent.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceParent.Service
{
    class ArticleService : IArticleService
    {
        private IArticleRepository reprository;
        public ArticleService()
        {
            reprository = new ArticleRepository();
        }
        public bool CheckArticleByUrl(string url)
        {
            return reprository.CheckArticleByUrl(url);
        }
    }
}
