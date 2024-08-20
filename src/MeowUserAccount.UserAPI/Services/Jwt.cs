using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MeowUserAccount.UserAPI.Services;

public class Jwt
{
    private readonly string _secretKey;
    private readonly string _issuer;

    public Jwt(IConfiguration configuration)
    {
        _secretKey = configuration["Jwt:Key"];
        _issuer = configuration["Jwt:Issuer"];
    }

    public string GenerateToken(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_secretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            }),
            Expires = DateTime.UtcNow.AddHours(1), // Token 1小时后过期
            Issuer = _issuer,
            Audience = _issuer,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}