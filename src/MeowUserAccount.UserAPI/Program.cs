using Npgsql;

namespace MeowUserAccount.UserAPI;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(PgSql.SqlConnString);
        
        
        NpgsqlConnection connection = new NpgsqlConnection(PgSql.SqlConnString);
        connection.Open();

        UserDatabase.Manage.Add(
            conn: connection,
            name: "aaa",
            start: 0,
            notes: "备注"
        );
        
        User.Register.AddUser(
            conn: connection,
            databaseId: 1,
            uid: "LaoMaoMAG",
            name: "爱打盹的猫",
            password: "laomao123456",
            email: "laomaomag@qq.com",
            phone: "15141543909",
            emailState: 0,
            phoneState: 0
        );

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
        // app.MapGet("/", () => "Hello, World!");
        app.Run();
    }
}