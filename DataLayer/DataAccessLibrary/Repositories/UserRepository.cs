using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccessLibrary.Repositories;

public class UserRepository : IUserRepository
{
    public UserRepository(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    IDataAccess _dataAccess;

    public async Task<int> InsertUserRecord(UserSignUpModel userData)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@firstName", userData.FirstName);
        parameters.Add("@lastName", userData.LastName);
        parameters.Add("@emailAddress", userData.Email);
        parameters.Add("@password", userData.Password);
        parameters.Add("@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output);
        await _dataAccess.SaveData("dbo.[spUser_Insert]", parameters, "SocietyManager");
        int userId = parameters.Get<int>("@UserId");
        return userId;
    }
}
