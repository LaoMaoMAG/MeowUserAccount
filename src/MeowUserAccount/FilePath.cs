namespace MeowUserAccount;

public class FilePath
{
    public static string DataFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
    
    public static string ConfigFilePath = Path.Combine(DataFolderPath, "Config.db");
    
    public static string OperationKeyFilePath = Path.Combine(DataFolderPath, "operationKey.json");
    
    static FilePath()
    {
        // 如果文件夹不存在，则创建它
        if (!Directory.Exists(DataFolderPath)) Directory.CreateDirectory(DataFolderPath);
    }
}