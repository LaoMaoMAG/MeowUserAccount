using Microsoft.AspNetCore.Mvc;

namespace MeowUserAccount.UserAPI.Controllers;

[ApiController]  
[Route("api/register")] 
public class Register
{
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