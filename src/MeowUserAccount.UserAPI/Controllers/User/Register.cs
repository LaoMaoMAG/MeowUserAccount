using Microsoft.AspNetCore.Mvc;

namespace MeowUserAccount.UserAPI.Controllers;

[ApiController]  
[Route("api/register")] 
public class Register
{
    private readonly Services.Jwt _jwtService;
    
    private readonly Services.User.Register _registerService;
    
    private readonly DbConnectionContext _dbConnectionContext;

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