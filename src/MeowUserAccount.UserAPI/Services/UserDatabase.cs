using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace MeowUserAccount.UserAPI.Services;

public class UserDatabase(DbConnectionContext dbConnectionContext) : ControllerBase
{
    /// <summary>
    /// 添加仓库
    /// </summary>
    public bool Add(string name, int start, string notes)
    {
        try
        {
            // 将用户信息写入数据库
            var insertSql = "INSERT INTO \"user_database\" (name, state, notes) VALUES (@name, @state, @notes)";
            var cmds = new NpgsqlCommand(insertSql, dbConnectionContext.Connection);
            cmds.Parameters.AddWithValue("@name", name);
            cmds.Parameters.AddWithValue("@state", start);
            cmds.Parameters.AddWithValue("@notes", notes);
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
}