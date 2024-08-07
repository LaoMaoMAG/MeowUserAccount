namespace BaseLib;

///<summary>
/// 单例模式
/// 继承直接使用
///</summary>
public class Singleton<T> where T : new()
{
    private static T? _instance;

    /// <summary>
    /// 单例模式需要实例化
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }

}