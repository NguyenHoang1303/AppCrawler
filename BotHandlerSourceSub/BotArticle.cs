using BotHandlerSourceSub.Queue;
using BotHandlerSourceSub.Service;
using BotHandlerSourceSub.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceSub
{
    class BotArticle
    {
        private MyQueue myQueue;
        public BotArticle()
        {
            myQueue = new MyQueue();
        }

        public void Start()
        {
            myQueue.Reciever();
        }
    }
}
