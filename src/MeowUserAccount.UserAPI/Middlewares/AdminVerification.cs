using System.Text.Json;

namespace MeowUserAccount.UserAPI.Middlewares;

public class AdminVerification
{
    private readonly RequestDelegate _next;

    public AdminVerification(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/api/admin") && context.Request.Method == HttpMethods.Post)
        {
            // 读取请求body
            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var jsonDoc = JsonDocument.Parse(requestBody);
            
            if (jsonDoc.RootElement.TryGetProperty("adminOperationKey", out var keyElement))
            {
                var adminOperationKey = keyElement.GetString();
                
                // 验证密钥
                if (Program.AppOperationKey != null && adminOperationKey == Program.AppOperationKey.GetKey("adminOperation")) // 替换为你的密钥
                {
                    context.Request.Body = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(requestBody));
                    await _next(context);
                    return;
                }
            }

            // 如果密钥无效，返回401 Unauthorized
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        // 如果路径不是 /api/admin 或者不是 POST 请求，直接处理请求
        await _next(context);
    }
}