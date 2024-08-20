using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace MeowUserAccount.UserAPI.Controllers;


[Route("api/login")]
[ApiController]
public class Login : ControllerBase
{
    [HttpPost("password")]
    public ActionResult PasswordVerification([FromBody] Models.Login request)
    {
        // 实体模型如果有错误返回 404 NotFound
        if (!ModelState.IsValid) return NotFound();

        switch (request.Type)
        {
            case "uuid":
                return Ok();
            case "uid":
                return Ok();
            case "email":
                return Ok();
            case "phone":
                return Ok();
        }

        return NotFound();
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