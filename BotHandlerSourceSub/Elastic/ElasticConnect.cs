using BotHandlerSourceSub.Entity;
using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceSub.Elastic
{
    class ElasticConnect
    {
        private static ElasticClient client;
        private static string IndexName = "articles";
        private static string ElasticUsername = "elastic";
        //private static string CloudId = "JonhnyNguyen:dXMtY2VudHJhbDEuZ2NwLmNsb3VkLmVzLmlvJDQxMDZkMmJiYjczZTRkNzdhYjFmZTcyZjE3MWYxY2U0JDQ3ZjYzMDUwOGVhNTRkYjQ5ZDUxYWQ5MTQ5NjFiYTY3";
        //private static string ElasticPassword = "HwkG8UeuXyWlzcBXkgbtgkxE";
        private static string CloudId = "ArticleDb:YXNpYS1zb3V0aGVhc3QxLmdjcC5lbGFzdGljLWNsb3VkLmNvbSRlNWNiMzViOTRhZGY0NTY3OTUyNmZlODIyODVlOWYwZCQ4ZDZjZmFiNzA5NzY0ZmU4OWY3NjgzNGMzZTUwNThjZg==";
        private static string ElasticPassword = "WCIOTg3vUSbRh6RFOgjmPup5";
        private static string DefaultIndex = "example-index";
        public static ElasticClient GetInstance()
        {
            if (client == null)
            {
                var connectionSettings = new ConnectionSettings(CloudId,
                new BasicAuthenticationCredentials(ElasticUsername, ElasticPassword))
                .DefaultIndex(DefaultIndex)
                .DefaultMappingFor<Article>(
                a => a.IndexName(IndexName));
                client = new ElasticClient(connectionSettings);
            }
            return client;
        }
    }
}
