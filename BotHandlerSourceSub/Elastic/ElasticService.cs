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


        public bool CheckArticleById(string id)
        {
            var ls = ElasticConnect.GetInstance().Search<Article>(s => s
                   .Query(q => q

                       .Bool(b => b

                           .Must(m =>

                               m.Match(mt1 => mt1.Field(f1 => f1.Id).Query(id))

                   ))));
            return ls.Documents.Count > 0;
        }

        public void Save(Article article)
        {
            ElasticConnect.GetInstance().IndexDocument(article);
        }

        public List<Article> GetAll()
        {
            var res =
                ElasticConnect.GetInstance()
                .Search<Article>
                (s => s.From(0)
                        .Size(10000)
                        .Query(q => q.MatchAll()));

            return (List<Article>)res.Documents;
        }
    }
}
