using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Api.DataAcces
{
    public class DBaccess : IDBaccess
    {
        private readonly IConfiguration _config;

        public DBaccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedprocedure, U parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedprocedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task Savedata<T>(string storedprocedure, T parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            await connection.ExecuteAsync(storedprocedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
