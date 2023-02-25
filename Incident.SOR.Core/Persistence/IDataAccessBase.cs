using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incident.SOR.Core.Persistence
{
    public interface IDataAccessBase
    {
        string ConnString { get; set; }

        Task<int> ExecuteNonQueryAsync(string queryToExec, object? parameters,
            CommandType commandType = CommandType.StoredProcedure, int? timeOut = 0);
        Task<T> ExecuteScalarAsync<T>(string queryToExec, object? parameters, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<T>> QueryListAsync<T>(string queryToExec, object? parameters = null, CommandType commandType = CommandType.StoredProcedure);
        Task<List<T>> QueryAsListAsync<T>(string queryToExec, object? parameters = null, CommandType commandType = CommandType.StoredProcedure);
        Task<T> QuerySingleOrDefaultAsync<T>(string queryToExec, object? parameters = null,
            CommandType commandType = CommandType.StoredProcedure);
        Task<T> QueryFirstOrDefaultAsync<T>(string queryToExec, object? parameters = null,
            CommandType commandType = CommandType.StoredProcedure);
    }
}
