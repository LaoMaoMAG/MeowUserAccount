using MeowUserAccount.UserAPI.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeowUserAccount.UserAPI.Controllers.AppExample.User;


[Route("api/login")]
[ApiController]
public class Login : ControllerBase
{
    // JWT 服务
    private readonly Jwt _jwtService;
    
    // 数据库上下文
    private readonly DbConnectionContext _dbConnectionContext;
    
    // 注册业务逻辑
    private readonly Services.AppExample.User.Login _loginService;

    public Login(Jwt jwtService, Services.AppExample.User.Login loginService, DbConnectionContext dbConnectionContext)
    {
        _jwtService = jwtService;
        _loginService = loginService;
        _dbConnectionContext = dbConnectionContext;
    }
    
    [HttpPost("password")]
    public ActionResult PasswordVerification([FromBody] Data.Login request)
    {
        // 实体模型如果有错误返回 404 NotFound
        if (!ModelState.IsValid) return Unauthorized();
        // 验证用户密码，返回UUID
        string? uuid = _loginService.PasswordLogin(request.Type, request.Id, request.Password);
        // 判断用户是否通过验证，未通过返回 401 错误
        if (uuid == null) return Unauthorized();
        // 用户通过验证，返回带有UUID的Token
        var token = _jwtService.GenerateToken(uuid);
        return Ok(new { Token = token });
    }


    [HttpGet("token")]
    [Authorize]
    public ActionResult Token()
    {
        var uuid = User.Identity?.Name;
        return Ok(new { Username = uuid });
    }
    

    [HttpPost("verification_code")]
    public void VerificationCode()
    {
        
    }
    
    
    /// <summary>
    /// 账号验证
    /// </summary>
    /// <param name="type"></param>
    /// <param name="id"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    private bool AccountVerification(string type, string id, string password)
    {
        
        
        return true;
    }
}