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
        private string GetAllQuery = "SELECT * FROM Articles";
        private string QueryGetArticleByUrl = "SELECT * FROM Articles WHERE UrlSource = @UrlSource";
        public List<Article> GetAll()
        {
            List<Article> articles = new();
            try
            {
                using var cnn = ConnectionHelper.GetConnectSql();
                cnn.Open();
                var command = new SqlCommand(GetAllQuery, cnn);
                var data = command.ExecuteReader();
                while (data.Read())
                {
                    articles.Add(CreateArticle(data));
                }
                return articles;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public bool CheckArticleByUrl(string urlSource)
        {
            try
            {
                using var cnn = ConnectionHelper.GetConnectSql();
                cnn.Open();
                var command = new SqlCommand(QueryGetArticleByUrl, cnn);
                command.Prepare();
                command.Parameters.AddWithValue("@UrlSource", urlSource);
                var data = command.ExecuteReader();
                return data.Read();
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
                Id = data.GetString(0),
                UrlSource = data.GetString(1),
                Title = data.GetString(2),
                Image = data.GetString(3),
                Description = data.GetString(4),
                Content = data.GetString(5),
                CategoryId = data.GetString(6),
                CreatedAt = data.GetInt64(7),
            };
        }
    }
}
