using BotHandlerSourceParent.Entity;
using BotHandlerSourceParent.Repository.IRepo;
using BotHandlerSourceParent.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BotHandlerSourceParent.Repository
{
    class ArticleRepository : IArticleRepository
    {
        private string InsertQuery = "SELECT * FROM Articles";
        private string QueryGetArticleByUrl = "SELECT * FROM Articles WHERE UrlSource = @UrlSource";
        public List<Article> GetAll()
        {
            List<Article> articles = new List<Article>();
            try
            {
                using (var cnn = ConnectionHelper.GetConnectSql())
                {
                    cnn.Open();
                    var command = new SqlCommand(InsertQuery, cnn);
                    var data = command.ExecuteReader();
                    while (data.Read())
                    {
                        articles.Add(CreateArticle(data));
                    }
                    return articles;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;

            }
        }

        public Article GetArticleByUrl(string urlSource)
        {
            try
            {
                using (var cnn = ConnectionHelper.GetConnectSql())
                {
                    cnn.Open();
                    var command = new SqlCommand(QueryGetArticleByUrl, cnn);
                    command.Prepare();
                    command.Parameters.AddWithValue("@UrlSource", urlSource);
                    var data = command.ExecuteReader();
                    return data.Read() ? CreateArticle(data) : null;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private Article CreateArticle(SqlDataReader data)
        {
            return new Article()
            {
                UrlSource = data.GetString(0),
                Title = data.GetString(1),
                Image = data.GetString(2),
                Description = data.GetString(3),
                Content = data.GetString(4),
                CategoryId = data.GetString(5),
                CreatedAt = data.GetInt64(6),
            };
        }
    }
}
