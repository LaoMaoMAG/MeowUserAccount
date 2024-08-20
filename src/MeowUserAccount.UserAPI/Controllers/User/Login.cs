using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeowUserAccount.UserAPI.Controllers;


[Route("api/login")]
[ApiController]
public class Login : ControllerBase
{
    private readonly Services.Jwt _jwtService;

    public Login(Services.Jwt jwtService)
    {
        _jwtService = jwtService;
    }
    
    [HttpPost("password")]
    public ActionResult PasswordVerification([FromBody] Models.Login request)
    {
        // 实体模型如果有错误返回 404 NotFound
        if (!ModelState.IsValid) return Unauthorized();
        
        switch (request.Type)
        {
            case "uuid":
                var token = _jwtService.GenerateToken(request.Id);
                return Ok(new { Token = token });
            case "uid":
                return Ok();
            case "email":
                return Ok();
            case "phone":
                return Ok();
        }

        return Unauthorized();
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