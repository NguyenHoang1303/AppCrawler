using BotHandlerSourceSub.Queue;
using BotHandlerSourceSub.Repository;
using BotHandlerSourceSub.Service;
using BotHandlerSourceSub.Util;
using System;

namespace BotHandlerSourceSub
{
    class Program
    {
        static void Main(string[] args)
        {
            new BotArticle().Start();

        }
    }
}
