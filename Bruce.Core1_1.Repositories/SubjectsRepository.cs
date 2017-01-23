using Bruce.Core1_1.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bruce.Core1_1.Repositories
{
    public class SubjectsRepository : BaseRepository
    {
        public int Insert(search_subject entity)
        {
            string sql = "INSERT INTO [douban_search_subject]([id],[rate],[cover_x],[cover_y],[title],[url],[cover],[is_beetle_subject],[playable],[is_new]) VALUES (@id, @rate, @cover_x, @cover_y, @title, @url, @cover, @is_beetle_subject, @playable, @is_new)";
            return base.Execute(OpenConnection(), sql, entity);
        }

        public int IsExist(string id)
        {
            //
            string sql = "SELECT COUNT(0) FROM [douban_search_subject] WHERE [id] = @id";
            return base.QuerySingle<int>(OpenConnection(), sql, new { id = id });
        }

        public List<search_subject> GetList()
        {
            string sql = "SELECT [id],[rate],[cover_x],[cover_y],[title],[url],[cover],[is_beetle_subject],[playable],[is_new] FROM [douban_search_subject]";
            return base.Query<search_subject>(OpenConnection(), sql);
        }
        public List<string> GetIdList()
        {
            string sql = "SELECT [id] FROM [douban_search_subject]";
            return base.Query<string>(OpenConnection(), sql);
        }
        //public List<string> GetNotExistIdList()
        //{
        //    string sql = "SELECT [id] FROM [douban_search_subject]";
        //    return base.Query<string>(OpenConnection(), sql);
        //}
    }
}
