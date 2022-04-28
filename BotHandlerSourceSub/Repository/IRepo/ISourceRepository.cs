using BotHandlerSourceSub.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceSub.Repository
{
    interface ISourceRepository
    {
        List<Source> GetAll();
    }
}
