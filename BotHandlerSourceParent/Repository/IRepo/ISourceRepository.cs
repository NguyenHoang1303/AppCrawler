using BotHandlerSourceParent.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceParent.Repository
{
    interface ISourceRepository
    {
        List<Source> GetAll();
    }
}
