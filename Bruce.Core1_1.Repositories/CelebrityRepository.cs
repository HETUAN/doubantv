using Bruce.Core1_1.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bruce.Core1_1.Repositories
{
    public class CelebrityRepository : BaseRepository
    {
        public int Insert(celebrity entity)
        {
            string sql = "INSERT INTO[Bruce].[dbo].[douban_celebrity] ([id],[name],[title],[sex],[birthday],[constellation],[occupation],[homeplace],[chname],[othernames],[imdbnum]) VALUES (@id,@NAME,@title,@sex,@birthday,@constellation,@occupation,@homeplace,@chname,@othernames,@imdbnum)";
            //string sql = "INSERT INTO [douban_celebrity]([id],[rate],[cover_x],[cover_y],[title],[url],[cover],[is_beetle_subject],[playable],[is_new]) VALUES (@id, @rate, @cover_x, @cover_y, @title, @url, @cover, @is_beetle_subject, @playable, @is_new)";
            return base.Execute(OpenConnection(), sql, entity);
        }

        public int IsExist(string id)
        {
            //
            string sql = "SELECT COUNT(0) FROM [douban_celebrity] WHERE [id] = @id";
            return base.QuerySingle<int>(OpenConnection(), sql, new { id = id });
        }
    }
}
