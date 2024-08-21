using MeowTools.WebUtility;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace MeowUserAccount.UserAPI.Services.AppExample.User;

public class Register(DbConnectionContext dbConnectionContext) : ControllerBase
{
    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="databaseId"></param>
    /// <param name="uid"></param>
    /// <param name="name"></param>
    /// <param name="password"></param>
    /// <param name="email"></param>
    /// <param name="phone"></param>
    /// <param name="emailState"></param>
    /// <param name="phoneState"></param>
    /// <returns></returns>
    public bool AddUser(int databaseId, string uid, string name, string password, string? email, string? phone, int emailState, int phoneState)
    {
        // 密码加密
        var salt = Password.GenerateSalt(); // 密码盐
        var hashPassword = Password.Encryption(password, salt); // 哈希密码

        try
        {
            // 查询用户库ID是否存在
            using var cmd = new NpgsqlCommand("SELECT EXISTS(SELECT 1 FROM user_database WHERE id = @userId)", dbConnectionContext.Connection);
            cmd.Parameters.AddWithValue("@userId", databaseId);
            bool exists = Convert.ToBoolean(cmd.ExecuteScalar());
            if (!exists) return false;

            // 将用户信息写入数据库
            var insertSql = "INSERT INTO \"user\" (database_id, uid, name, password, salt, email, phone, email_state, phone_state) VALUES (@warehouse_id, @uid, @name, @password, @salt, @email, @phone, @email_state, @phone_state)";
            var cmds = new NpgsqlCommand(insertSql, dbConnectionContext.Connection);
            cmds.Parameters.AddWithValue("@warehouse_id", databaseId);
            cmds.Parameters.AddWithValue("@uid", uid);
            cmds.Parameters.AddWithValue("@name", name);
            cmds.Parameters.AddWithValue("@password", hashPassword);
            cmds.Parameters.AddWithValue("@salt", salt);
            cmds.Parameters.AddWithValue("@email", email);
            cmds.Parameters.AddWithValue("@phone", phone);
            cmds.Parameters.AddWithValue("@email_state", emailState);
            cmds.Parameters.AddWithValue("@phone_state", phoneState);
            int result = cmds.ExecuteNonQuery();
            if (result <= 0) return false;
        }
        catch (Exception error)
        {
            Console.WriteLine($"SQL语句错误:\n{error}");
            return false;
        }

        return true;
    }


    public string? GetUuid(NpgsqlConnection conn, string type, string value)
    {
        if (type != "uid" && type != "name") return null;
        
        try
        {
            // 构造SQL查询语句
            string query = "SELECT uuid FROM \"user\" WHERE @type = @UserName";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@UserName", value);

            // 执行查询并获取结果  
            object result = cmd.ExecuteScalar();
        
            // 检查是否找到了结果  
            if (result != null && result != DBNull.Value) return result.ToString();
        }
        catch (Exception error)
        {
            Console.WriteLine($"SQL语句错误:\n{error}");
            return null;
        }
        
        return null;
    }
}