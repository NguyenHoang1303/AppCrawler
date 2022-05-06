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
        private string InsertQuery = "INSERT INTO Articles( UrlSource, Title, Image, Description, Content, CategoryId, CreatedAt )" +
            " VALUES ( @UrlSource, @Title, @Image, @Description, @Content, @CategoryId, @CreatedAt ) ";

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

        public Article GetArticleByUrl(string urlSource)
        {
            try
            {
                using var cnn = ConnectionHelper.GetConnectSql();
                cnn.Open();
                var command = new SqlCommand(QueryGetArticleByUrl, cnn);
                command.Prepare();
                command.Parameters.AddWithValue("@UrlSource", urlSource);
                var data = command.ExecuteReader();
                return data.Read() ? CreateArticle(data) : null;
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
                command.Prepare();
                command.Parameters.AddWithValue("@UrlSource", article.UrlSource);
                command.Parameters.AddWithValue("@Title", article.Title);
                command.Parameters.AddWithValue("@Image", article.Image);
                command.Parameters.AddWithValue("@Description", article.Description);
                command.Parameters.AddWithValue("@Content", article.Content);
                command.Parameters.AddWithValue("@CategoryId", article.CategoryId);
                command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.Ticks);
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
