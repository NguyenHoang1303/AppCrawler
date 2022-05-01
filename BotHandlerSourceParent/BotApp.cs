using BotHandlerSourceParent.Entity;
using BotHandlerSourceParent.Queue;
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
    class BotApp
    {
        private ISourceService sourceService;
        private MyQueue myQueue;
        public BotApp()
        {
            sourceService = new SourceService();
            myQueue = new();
        }

        public async Task Start()
        {
            var listSource = sourceService.GetAll();
            foreach(var source in listSource)
            {
               var listEvent = sourceService.GetSubLink(source);
               foreach(var eventQueue in listEvent)
                {
                    myQueue.Sender(eventQueue);
                }
            }

            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();

            // and start it off
            await scheduler.Start();

            // some sleep to show what's happening
            await Task.Delay(TimeSpan.FromSeconds(10));

            // and last shut down the scheduler when you are ready to close your program
            await scheduler.Shutdown();

        }
    }
}
