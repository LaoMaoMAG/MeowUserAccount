using System.Text;
using Npgsql;

namespace MeowUserAccount.UserAPI;

public class PgSql
{
    public static string SqlConnString { get; set; }
    public NpgsqlConnection SqlConnection  { get; set; }
    
    private NpgsqlConnection _sqlConnection;
    
    
    /// <summary>
    /// 构造方法
    /// </summary>
    public PgSql()
    {
        SqlConnection = new NpgsqlConnection(SqlConnString);
        SqlConnection.Open();
    }


    /// <summary>
    /// 关闭SQL连接
    /// </summary>
    public void Close()
    {
        SqlConnection.Close();
    }
    
    
    /// <summary>
    /// 静态构造
    /// </summary>
    static PgSql()
    {
        // 初始化服务器配置
        var configData = new MeowTools.ConfigDB(FilePath.ConfigFilePath, "PostgreSQL");
        configData.Init("Server", "127.0.0.1");
        configData.Init("Port", 5432);
        configData.Init("DbName", "mua_user_api");
        configData.Init("UserName", "postgres");
        configData.Init("Password", "laomao123456");
        
        // 拼接连接字符串
        var server = configData.Get<string>("Server");
        var port = configData.Get<int>("Port").ToString();
        var userName = configData.Get<string>("UserName");
        var password = configData.Get<string>("Password");
        var dbName = configData.Get<string>("DbName");
        SqlConnString = $"Host={server};Port={port};Username={userName};Password={password};Database={dbName}";
        string folderPath = "sql";
        
        // 初始化数据表
        var connect = new NpgsqlConnection(SqlConnString);
        connect.Open();  
        foreach (var filePath in Directory.GetFiles(folderPath, "*.sql"))  
        {  
            string sql = File.ReadAllText(filePath, Encoding.UTF8);

            var cmd = new NpgsqlCommand(sql, connect);
            try  
            {  
                cmd.ExecuteNonQuery();  
                Console.WriteLine($"执行创建表 SQL文件: {filePath}");  
            }  
            catch (Exception ex)  
            {  
                Console.WriteLine($"执行创建表错误! SQL文件: {filePath}\n{ex.Message}");  
            }
        } 
        connect.Close();
    }
}