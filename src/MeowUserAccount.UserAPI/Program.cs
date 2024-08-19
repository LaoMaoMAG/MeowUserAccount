namespace MeowUserAccount.UserAPI;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(SqlData.SqlConnString);
        
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
        var app = builder.Build();
        // 配置 HTTP 请求管道
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers(); // 映射控制器路由
        app.MapGet("/", () => "Hello, World!");
        app.Run();
    }
}