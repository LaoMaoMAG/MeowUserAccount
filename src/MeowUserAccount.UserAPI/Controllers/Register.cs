using Microsoft.AspNetCore.Mvc;

namespace MeowUserAccount.UserAPI.Controllers;

[ApiController]  
[Route("register")] 
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
    private void SendVerCode()
    {
        
    }
    
    /// <summary>
    /// 提交验证码
    /// </summary>
    private void SubmitVerCode()
    {
        
    }

    /// <summary>
    /// 确定注册
    /// </summary>
    private void OkRegister()
    {
        
    }
    
    /// <summary>
    /// 取消注册
    /// </summary>
    private void CancelRegister()
    {
        
    }
}