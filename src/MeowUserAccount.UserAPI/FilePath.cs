namespace MeowUserAccount.UserAPI;

public class FilePath
{
    public static string DataFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
    
    public static string ConfigFilePath = Path.Combine(DataFolderPath, "Config.db");
    
    static FilePath()
    {
        // 如果文件夹不存在，则创建它
        if (!Directory.Exists(DataFolderPath)) Directory.CreateDirectory(DataFolderPath);
    }
}