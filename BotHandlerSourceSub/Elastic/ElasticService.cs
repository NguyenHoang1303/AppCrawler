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
    class ElasticService
    {
        private static ElasticClient client;
        private static string IndexName = "articles";
        private static string CloudId = "JonhnyNguyen:dXMtY2VudHJhbDEuZ2NwLmNsb3VkLmVzLmlvJDQxMDZkMmJiYjczZTRkNzdhYjFmZTcyZjE3MWYxY2U0JDQ3ZjYzMDUwOGVhNTRkYjQ5ZDUxYWQ5MTQ5NjFiYTY3";
        private static string ElasticUsername = "elastic";
        private static string ElasticPassword = "HwkG8UeuXyWlzcBXkgbtgkxE";
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
