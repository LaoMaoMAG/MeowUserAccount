using Microsoft.AspNetCore.Mvc;

namespace MeowUserAccount.UserAPI.Controllers;

[ApiController]  
[Route("image_verification_code")]  
public class ImageVerificationCode : ControllerBase
{
    /// <summary>
    /// 请求验证码
    /// </summary>
    [HttpGet("request")] 
    public void Request()
    {
        
    }

    
    /// <summary>
    /// 提交验证码
    /// </summary>
    [HttpGet("submit")] 
    public void Submit()
    {
        
    }
}