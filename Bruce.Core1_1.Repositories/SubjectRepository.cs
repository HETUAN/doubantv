using Bruce.Core1_1.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bruce.Core1_1.Repositories
{
    public class SubjectRepository : BaseRepository
    {
        public int Insert(subject entity)
        {
            string sql = "INSERT INTO[Bruce].[dbo].[douban_subject] ([id],[types],[release_year],[playable],[region],[duration],[actors],[directors],[subtype],[is_tv],[rate],[collection_status],[url],[title],[blacklisted],[star],[episodes_count],[actors_id],[directors_id],[bianjus],[bianjus_id]) VALUES (@id ,@types ,@release_year ,@playable ,@region ,@duration ,@actors ,@directors ,@subtype ,@is_tv,@rate,@collection_status,@url,@title,@blacklisted,@star,@episodes_count,@actors_id,@directors_id,@bianjus,@bianjus_id)";
            return base.Execute(OpenConnection(), sql, entity);
        }

        public int IsExist(string id)
        {
            //
            string sql = "SELECT COUNT(0) FROM [douban_subject] WHERE [id] = @id";
            return base.QuerySingle<int>(OpenConnection(), sql, new { id = id });
        }
        public List<string> GetIdList()
        {
            string sql = "SELECT [id] FROM [douban_subject]";
            return base.Query<string>(OpenConnection(), sql);
        }
    }
}
