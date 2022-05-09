using BotHandlerSourceSub.App;
using BotHandlerSourceSub.Entity;
using Nest;
using System;
using System.Threading.Tasks;

namespace BotHandlerSourceSub
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //CronJopApp cronJob = new();
            //await cronJob.Run();
            var settings = new ConnectionSettings(new Uri("http://elastic:FKU5nCdN1N_-qSWFcTvd@localhost:9200")).DefaultIndex("db_Appcrawler");

            var client = new ElasticClient(settings);
            var article = new Article()
            {
                UrlSource = "testUrl-1",
                Image = "image-1.png",
                Description = "description-1",
                Content = "content-1",
                CategoryId = "Hoo-1",
                CreatedAt = DateTime.Now.Ticks
            };
            var indexResponse = client.IndexDocument(article);
            //Console.WriteLine(indexResponse.ToString());
            var searchResponse = client.Search<Article>(s => s
                                        .From(0)
                                        .Size(10)
                                        .Query(q => q
                                             .Match(m => m
                                                .Field(f => f.UrlSource)
                                                .Query("testUrl")
                                             )
                                        )
                                    );

            var document = searchResponse.Documents;
            Console.WriteLine(document.Count);
            foreach(Article a in document)
            {
                Console.WriteLine("TsssS");
                Console.WriteLine("url: " + a.UrlSource);
            }
            Console.WriteLine("document: " + document);
        }
    }
}
