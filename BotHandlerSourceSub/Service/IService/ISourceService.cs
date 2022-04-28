using BotHandlerSourceSub.Entity;
using BotHandlerSourceSub.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceSub.Service
{
    interface ISourceService
    {
        List<Source> GetAll();
       
    }
}
