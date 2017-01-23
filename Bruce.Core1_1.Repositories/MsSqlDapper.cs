using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Bruce.Core.Test.Common
{
    public class MsSqlDapper
    {
        protected string _mySqlConnectStr;

        #region dapper 封装方法
        protected T QuerySingle<T>(IDbConnection sqlConnection, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (sqlConnection)
            {
                var result = sqlConnection.Query<T>(sql, param, null, buffered, commandTimeout, commandType);
                if (result == null)
                    return default(T);

                return result.FirstOrDefault();
            }
        }

        protected List<T> Query<T>(IDbConnection sqlConnection, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (sqlConnection)
            {
                var result = sqlConnection.Query<T>(sql, param, null, buffered, commandTimeout, commandType).ToList();
                return result;
            }
        }

        protected int Execute(IDbConnection sqlConnection, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (sqlConnection)
            {
                var result = sqlConnection.Execute(sql, param, null, commandTimeout, commandType);
                return result;
            }
        }
        protected SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(_mySqlConnectStr);
            connection.Open();
            return connection;
        }
        #endregion
    }
}
