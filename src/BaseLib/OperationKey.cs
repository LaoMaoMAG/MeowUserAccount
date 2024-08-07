using DanKeJson;

namespace BaseLib;

/// <summary>
/// 操作密钥
/// </summary>
public class OperationKey
{
    // 密钥文件
    public static string KeyFilePath = Path.Combine(FilePath.DataFolderPath, "OperationKey.json");
    // 密钥
    public static string? Key { get; private set; }

    // 默认密钥长度
    private static int _defaultKeyLength = 64;

    private class Data
    {
        private string? _key;

        public string? Key
        {
            get => _key;
            set => _key = value ?? GenerateKey(_defaultKeyLength);
        }
    }
    
    
    /// <summary>
    /// 静态构造
    /// </summary>
    static OperationKey()
    {
        // 初始化密钥文件
        if (!File.Exists(KeyFilePath))
        {
            SetKey();
        }
        else
        {
            ReadKey();   
        }
    }


    /// <summary>
    /// 设置密钥
    /// </summary>
    /// <param name="key"></param>
    public static void SetKey(string? key = null)
    {
        // 设置密钥
        var json = JSON.ToJson(new Data
        {
            Key = key
        });
        File.WriteAllText(KeyFilePath, json);
        
        // 读取密钥
        ReadKey();
    }


    /// <summary>
    /// 读取密钥
    /// </summary>
    public static void ReadKey()
    {
        Data data = JSON.ToData<Data>(File.ReadAllText(KeyFilePath));
        string key = data.Key ?? throw new InvalidOperationException();
        Key = key;
    }
    
    
    /// <summary>
    /// 生成随机密钥
    /// </summary>
    /// <param name="length">密钥长度</param>
    /// <returns></returns>
    private static string GenerateKey(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var result = new char[length];
        for (int i = 0; i < length; i++) result[i] = chars[random.Next(chars.Length)];
        return new string(result);
    }
}