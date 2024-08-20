using Microsoft.AspNetCore.Mvc;

namespace MeowUserAccount.UserAPI.Controllers;

[ApiController]  
[Route("api/register")] 
public class Register
{
    // JWT 服务
    private readonly Services.Jwt _jwtService;
    
    // 数据库上下文
    private readonly DbConnectionContext _dbConnectionContext;
    
    // 注册业务逻辑
    private readonly Services.User.Register _registerService;

    public Register(Services.Jwt jwtService, Services.User.Register registerService, DbConnectionContext dbConnectionContext)
    {
        _jwtService = jwtService;
        _registerService = registerService;
        _dbConnectionContext = dbConnectionContext;
    }
    
    /// <summary>
    /// 提交用户数据
    /// </summary>
    [HttpPost("submit_data")]  
    public void SubmitData([FromBody] Models.Register request)
    {
        
    }
    
    
    /// <summary>
    /// 发送验证码
    /// </summary>
    [HttpPost("send_verification_code")]  
    public void SendVerCode()
    {
        
    }
}