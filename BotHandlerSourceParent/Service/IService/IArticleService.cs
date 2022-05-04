using BotHandlerSourceParent.Entity;

namespace BotHandlerSourceParent.Service.IService
{
    interface IArticleService
    {
        Article GetArticleByUrl(string url); 
    }
}
