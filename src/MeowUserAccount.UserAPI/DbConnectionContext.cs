using Npgsql;
using System;

namespace MeowUserAccount.UserAPI;

/// <summary>
/// 数据库连接生命周期上下文管理
/// </summary>
public class DbConnectionContext : IDisposable
{
    private readonly NpgsqlConnection _connection;

    public DbConnectionContext(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
        _connection.Open();
    }

    public NpgsqlConnection Connection => _connection;

    public void Dispose()
    {
        _connection?.Dispose();
    }
}