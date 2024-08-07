using Microsoft.AspNetCore.Mvc;

namespace UserAPI.Controllers;

[ApiController]  
[Route("register/[controller]")] 
public class Register
{
    /// <summary>
    /// 提交用户数据
    /// </summary>
    [HttpGet("{id}")]  
    public void SubmitUserData()
    {
        
    }

    /// <summary>
    /// 发送验证码
    /// </summary>
    public void SendVerCode()
    {
        
    }
    
    /// <summary>
    /// 提交验证码
    /// </summary>
    public void SubmitVerCode()
    {
        
    }

    /// <summary>
    /// 确定注册
    /// </summary>
    public void OkRegister()
    {
        
    }
    
    /// <summary>
    /// 取消注册
    /// </summary>
    public void CancelRegister()
    {
        
    }
}