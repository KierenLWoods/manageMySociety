using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

public class SQLDataAccess : IDataAccess
{
    public SQLDataAccess(IConfiguration config, string name)
    {
        _config = config;
        _connectionString = GetConnectionString(name);
    }

    public IConfiguration _config { get; }
    private string _connectionString { get; }

    public string GetConnectionString(string name)
    {
        return _config.GetConnectionString(name);
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(
        string storedProcedure,
        U parameters,
        string connectionStringName
    )
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            return await connection.QueryAsync<T>(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }

    public async Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
    {
        string connectionString = GetConnectionString(connectionStringName);
        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            await connection.ExecuteAsync(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
