using BotHandlerSourceSub.App;
using BotHandlerSourceSub.Elastic;
using BotHandlerSourceSub.Entity;
using BotHandlerSourceSub.Repository;
using Nest;
using System;
using System.Threading.Tasks;

namespace BotHandlerSourceSub
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CronJopApp cronJob = new();
            await cronJob.Run();
        }
    }
}
