using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public interface IDataAccess
{
    IConfiguration _config { get; }
    string GetConnectionString(string name);

    Task<IEnumerable<T>> LoadData<T, U>(
        string storedProcedure,
        U parameters,
        string connectionStringName
    );
    Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
}
