using BotHandlerSourceParent.Entity;
using BotHandlerSourceParent.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BotHandlerSourceParent.Repository
{
    class SourceRepository : ISourceRepository
    {
        private string InsertQuery = "SELECT * FROM Source";
        public List<Source> GetAll()
        {
            List<Source> sources = new List<Source>();
            try
            {
                using var cnn = ConnectionHelper.GetConnectSql();
                cnn.Open();
                var command = new SqlCommand(InsertQuery, cnn);
                var data = command.ExecuteReader();
                while (data.Read())
                {
                    var source = new Source()
                    {
                        Id = data.GetString(0),
                        Url = data.GetString(1),
                        SelectorSubUrl = data.GetString(2),
                        SelectorTitle = data.GetString(3),
                        SelectorImage = data.GetString(4),
                        SelectorDescrition = data.GetString(5),
                        SelectorContent = data.GetString(6),
                        CategoryId = data.GetString(7),
                    };
                    sources.Add(source);
                    Console.WriteLine(source.ToString());
                }
                return sources;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;

            }
        }


    }
}
