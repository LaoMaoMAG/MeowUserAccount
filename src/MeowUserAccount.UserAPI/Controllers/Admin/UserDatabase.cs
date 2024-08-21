
using Microsoft.AspNetCore.Mvc;

namespace MeowUserAccount.UserAPI.Controllers.Admin;

[Route("api/admin/user_database")]
[ApiController]
public class UserDatabase : ControllerBase
{
    // 数据库上下文
    private readonly DbConnectionContext _dbConnectionContext;
    
    // 注册业务逻辑
    private readonly Services.UserDatabase _userDatabase;

    public UserDatabase(Services.UserDatabase userDatabase, DbConnectionContext dbConnectionContext)
    {
        _userDatabase = userDatabase;
        _dbConnectionContext = dbConnectionContext;
    }
    
    [HttpPost]
    public ActionResult AddDatabase([FromBody] Models.Admin.AddDatabase request)
    {
        var state = _userDatabase.Add(request.Name, request.State, request.Notes);
        
        return Ok();
    }
}