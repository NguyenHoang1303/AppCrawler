using BotHandlerSourceParent.Entity;
using BotHandlerSourceParent.Queue;
using BotHandlerSourceParent.Repository;
using BotHandlerSourceParent.Service;
using BotHandlerSourceParent.Util;

namespace BotHandlerSourceParent
{
    class Program
    {
        static void Main(string[] args)
        {
            new BotApp().Start();
            
        }
    }
}
