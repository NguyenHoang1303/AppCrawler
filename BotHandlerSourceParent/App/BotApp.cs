using BotHandlerSourceParent.Entity;
using BotHandlerSourceParent.Queue;
using BotHandlerSourceParent.Service.IService;
using BotHandlerSourceParent.Service;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceParent
{
    class BotApp : IJob
    {
        private ISourceService sourceService;
        private MyQueue myQueue;
        private List<Source> listSource;
        public BotApp()
        {
        }

        public async Task Execute(IJobExecutionContext context)
        {
            sourceService = new SourceService();
            myQueue = new();
            listSource = sourceService.GetAll();

            foreach (var source in listSource)
            {
                var listEvent = sourceService.GetSubLink(source);
                foreach (var eventQueue in listEvent)
                {
                    Console.WriteLine(eventQueue.Url);
                    myQueue.Sender(eventQueue);
                }
            }

        }

    }
}
