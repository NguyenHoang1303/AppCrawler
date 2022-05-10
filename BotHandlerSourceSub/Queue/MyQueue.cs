using BotHandlerSourceSub.Elastic;
using BotHandlerSourceSub.Entity;
using BotHandlerSourceSub.Service;
using BotHandlerSourceSub.Service.IService;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace BotHandlerSourceSub.Queue
{
    class MyQueue
    {
        private IArticleService articleService;
        private ElasticService elastic;

        public MyQueue()
        {
            articleService = new ArticleService();
            elastic = new ElasticService();
        }

        public void Reciever()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "crawler",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                
                var message = Encoding.UTF8.GetString(body);
                EventQueue eventQueue = JsonConvert.DeserializeObject<EventQueue>(message);
                HandlerEvenQueue(eventQueue);

            };
            channel.BasicConsume(queue: "crawler",
                                 autoAck: true,
                                 consumer: consumer);
            Console.ReadLine();
        }

        private void HandlerEvenQueue(EventQueue eventQueue)
        {
            var article = articleService.GetArticle(eventQueue);
            var i = 0;
            if (article != null)
            {
                var a = articleService.Save(article);
                if (!elastic.CheckArticleById(a.Id))
                {
                    elastic.Save(article);
                }

                Console.WriteLine(" [x] Received{0}:  {1}", i++, article.UrlSource);
            }
        }
    }
}
