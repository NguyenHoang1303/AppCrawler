using BotHandlerSourceSub.Queue;
using BotHandlerSourceSub.Service;
using BotHandlerSourceSub.Service.IService;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceSub
{
    class BotArticle : IJob
    {
        private MyQueue myQueue;
        public BotArticle()
        {
            myQueue = new MyQueue();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await Start();
        }

        public async Task Start()
        {
            myQueue.Reciever();
        }
    }
}
