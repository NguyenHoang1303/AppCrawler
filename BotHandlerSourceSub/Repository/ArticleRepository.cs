using BotHandlerSourceSub.Entity;
using BotHandlerSourceSub.Repository.IRepo;
using BotHandlerSourceSub.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceSub.Repository
{
    class ArticleRepository : IArticleRepository
    {
        private string GetAllQuery = "SELECT * FROM Articles";
        private string QueryGetArticleByUrl = "SELECT * FROM Articles WHERE UrlSource = @UrlSource";
        private string InsertQuery = "INSERT INTO Articles(Id, UrlSource, Title, Image, Description, Content, CategoryId, CreatedAt )" +
            " VALUES (@Id, @UrlSource, @Title, @Image, @Description, @Content, @CategoryId, @CreatedAt ) ";

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
                return data.Read() ? true : false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Article Save(Article article)
        {
            try
            {
                using var cnn = ConnectionHelper.GetConnectSql();
                cnn.Open();
                var command = new SqlCommand(InsertQuery, cnn);
                article.Id = Guid.NewGuid().ToString();
                article.CreatedAt = DateTime.Now.Ticks;
                command.Prepare();
                command.Parameters.AddWithValue("@Id", article.Id);
                command.Parameters.AddWithValue("@UrlSource", article.UrlSource);
                command.Parameters.AddWithValue("@Title", article.Title);
                command.Parameters.AddWithValue("@Image", article.Image);
                command.Parameters.AddWithValue("@Description", article.Description);
                command.Parameters.AddWithValue("@Content", article.Content);
                command.Parameters.AddWithValue("@CategoryId", article.CategoryId);
                command.Parameters.AddWithValue("@CreatedAt", article.CreatedAt);
                command.ExecuteNonQuery();
                return article;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        private static Article CreateArticle(SqlDataReader data)
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
