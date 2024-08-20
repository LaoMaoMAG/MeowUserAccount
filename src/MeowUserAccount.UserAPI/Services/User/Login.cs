using Microsoft.AspNetCore.Mvc;

namespace MeowUserAccount.UserAPI.Services.User;

public class Login : ControllerBase 
{
    private readonly DbConnectionContext _dbConnectionContext;

    public Login(DbConnectionContext dbConnectionContext)
    {
        _dbConnectionContext = dbConnectionContext;
    }
}