using Dapper;
using Incident.SOR.Domain.Configs;
using System.Data;
using System.Data.SqlClient;

namespace Incident.SOR.Core.Persistence
{
    public class DataAccessBase : IDataAccessBase
    {
        public string ConnectionString;
        private static int timeoutSeconds => 500;
        public string ConnString
        {
            get => ConnectionString;
            set
            {
                ConnectionString = value;
            }
        }
        private ConnectionStrings connectionStrings;
        public DataAccessBase(ConnectionStrings connectionString)
        {
            this.connectionStrings = connectionString;
            if (connectionString != null)
            {
                ConnString = this.connectionStrings.MainConnection;
            }
        }

        private async Task<IDbConnection> CreateOpenConnection(string ConnectionString)
        {
            var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();
            return connection;
        }

        public async Task<int> ExecuteNonQueryAsync(string queryToExec, object parameters, CommandType commandType = CommandType.StoredProcedure, int? timeOut = 0)
        {
            using (var connection = await CreateOpenConnection(ConnectionString))
            {
                return await connection.ExecuteAsync(queryToExec, parameters, null, timeoutSeconds, commandType);
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string queryToExec, object parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = await CreateOpenConnection(ConnectionString))
            {
                return await connection.ExecuteScalarAsync<T>(queryToExec, parameters, null, timeoutSeconds, commandType);
            }
        }

        public async Task<IEnumerable<T>> QueryListAsync<T>(string queryToExec, object? parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = await CreateOpenConnection(ConnectionString))
            {
                return await connection.QueryAsync<T>(queryToExec, parameters, null, timeoutSeconds, commandType);
            }
        }
        public async Task<List<T>> QueryAsListAsync<T>(string queryToExec, object? parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = await CreateOpenConnection(ConnectionString))
            {
                return (await connection.QueryAsync<T>(queryToExec, parameters, null, timeoutSeconds, commandType)).ToList();
            }
        }
        public async Task<T> QuerySingleOrDefaultAsync<T>(string queryToExec, object? parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = await CreateOpenConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<T>(queryToExec, parameters, null, timeoutSeconds, commandType);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string queryToExec, object parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = await CreateOpenConnection(ConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<T>(queryToExec, parameters, null, timeoutSeconds, commandType);
            }
        }
    }
}
