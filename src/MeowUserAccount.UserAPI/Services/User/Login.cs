using Microsoft.AspNetCore.Mvc;
using Npgsql;
using MeowTools.WebUtility;

namespace MeowUserAccount.UserAPI.Services.User;

public class Login(DbConnectionContext dbConnectionContext) : ControllerBase
{
    /// <summary>
    /// 密码登录
    /// </summary>
    /// <param name="type"></param>
    /// <param name="id"></param>
    /// <param name="password"></param>
    /// <returns>登录成功：用户UUID 登录失败：NULL</returns>
    public string? PasswordLogin(string type, string id, string password)
    {
        // 去除前后空格
        type = type.Trim();
        id = id.Trim();
        password = password.Trim();
        
        // 判断是否有空数据
        if (type == "" || id == "" || password == "") return null;
        
        // 判断类型是否符合要求
        if (type != "uuid" && type != "uid" && type != "email" && type != "phone") return null;

        try
        {
            // 创建 SQL 查询语句
            string query = $"SELECT uuid, password, salt FROM \"user\" WHERE {type} = @value";

            using var cmd = new NpgsqlCommand(query, dbConnectionContext.Connection);
            // 添加参数防止 SQL 注入
            cmd.Parameters.AddWithValue("@value", id);

            // 执行查询
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            
            // 获取数据
            string userUuid = reader.GetGuid(reader.GetOrdinal("uuid")).ToString();
            string userPassword = (string)reader["password"];
            byte[] userSalt = (byte[])reader["salt"];
            
            // 验证密码
            if (!Password.Verify(password, userPassword, userSalt)) return null;

            return userUuid;
        }
        catch (Exception error)
        {
            Console.WriteLine($"SQL语句错误:\n{error}");
            return null;
        }
    }
}