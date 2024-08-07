namespace BaseLib;

public class FilePath
{
    public static string DataFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
    
    static FilePath()
    {
        // 如果文件夹不存在，则创建它
        if (!Directory.Exists(DataFolderPath)) Directory.CreateDirectory(DataFolderPath);
    }
}