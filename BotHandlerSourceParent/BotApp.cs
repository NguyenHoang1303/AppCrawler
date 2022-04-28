using BotHandlerSourceParent.Entity;
using BotHandlerSourceParent.Queue;
using BotHandlerSourceParent.Service;
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

        public void Start()
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

        }
    }
}
