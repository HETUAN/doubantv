using Bruce.Core1_1.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bruce.Core1_1.Repositories
{
    public class CeleSubjectRepository : BaseRepository
    {
        public int Insert(cele_subject entity)
        {
            string sql = "INSERT INTO [douban_cele_subject] ([celebrity_id],[subject_id],[subject_title]) VALUES (@celebrity_id , @subject_id , @subject_title)";
            return base.Execute(OpenConnection(), sql, entity);
        }

        public int IsExist(string celebrity_id, string subject_id)
        {
            string sql = "SELECT COUNT(0) FROM [douban_cele_subject] WHERE [celebrity_id] = @celebrity_id AND subject_id = @subject_id";
            return base.QuerySingle<int>(OpenConnection(), sql, new { celebrity_id = celebrity_id, subject_id = subject_id });
        }
    }
}