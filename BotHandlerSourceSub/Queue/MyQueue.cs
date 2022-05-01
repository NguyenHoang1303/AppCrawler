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

        public MyQueue()
        {
            articleService = new ArticleService();
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
                var i = 0;
                var message = Encoding.UTF8.GetString(body);
                EventQueue eventQueue = JsonConvert.DeserializeObject<EventQueue>(message);
                var article = articleService.GetArticle(eventQueue);
                articleService.Save(article);
                Console.WriteLine(" [x] Received{0}:  {1}",i++, article.Image);
            };
            channel.BasicConsume(queue: "crawler",
                                 autoAck: true,
                                 consumer: consumer);
            Console.ReadLine();
        }
    }
}
