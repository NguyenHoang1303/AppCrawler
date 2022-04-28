using BotHandlerSourceParent.Entity;
using BotHandlerSourceParent.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceParent.Service
{
    interface ISourceService
    {
        List<Source> GetAll();
        HashSet<EventQueue> GetSubLink(Source source);
    }
}
