using MeowTools.WebUtility;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Npgsql;

namespace MeowUserAccount.UserAPI;

public class Program
{
    public static OperationKey? AppOperationKey { get; set; }
    
    public static void Main(string[] args)
    {
        AppOperationKey = new OperationKey(FilePath.OperationKeyFilePath);
        // AppOperationKey.SetKey("adminOperation");
        
        Console.WriteLine(PgSql.SqlConnString);

        NpgsqlConnection connection = new NpgsqlConnection(PgSql.SqlConnString);
        connection.Open();

        /*
        UserDatabase.Manage.Add(
            name: "aaa",
            start: 0,
            notes: "备注"
        );
        Register.AddUser(
            databaseId: 1,
            uid: "LaoMaoMAG",
            name: "爱打盹的猫",
            password: "laomao123456",
            email: "laomaomag@qq.com",
            phone: "15141543909",
            emailState: 0,
            phoneState: 0
        );
        */

        StartServer(args);
    }

    private static void StartServer(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // 添加控制器服务
        builder.Services.AddControllers();
        // 添加其他服务
        builder.Services.AddAuthorization();
        // 配置 Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // 添加 JWT 认证服务
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

        builder.Services.AddControllers();

        // 配置 DbConnectionContext 为 Scoped 生命周期
        builder.Services.AddScoped(serviceProvider => new DbConnectionContext(PgSql.SqlConnString));

        // 注册 JWT 服务
        builder.Services.AddScoped<Services.Jwt>();

        // 注册业务逻辑服务
        builder.Services.AddScoped<Services.User.Register>();
        builder.Services.AddScoped<Services.User.Login>();

        var app = builder.Build();
        // 配置 HTTP 请求管道
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // 添加管理员认证中间件
        app.UseMiddleware<Middlewares.AdminVerification>();

        // 使用认证和授权中间件
        app.UseAuthentication(); // 添加身份验证中间件 要在授权之前认证，这个和[Authorize]特性有关
        app.UseAuthorization();

        // 映射控制器路由
        app.MapControllers();

        // 开启服务
        app.Run();
    }
}