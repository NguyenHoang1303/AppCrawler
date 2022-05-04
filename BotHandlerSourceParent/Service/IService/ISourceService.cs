using BotHandlerSourceParent.Entity;
using BotHandlerSourceParent.Queue;
using System.Collections.Generic;

namespace BotHandlerSourceParent.Service.IService
{
    interface ISourceService
    {
        List<Source> GetAll();
        HashSet<EventQueue> GetSubLink(Source source);
    }
}
