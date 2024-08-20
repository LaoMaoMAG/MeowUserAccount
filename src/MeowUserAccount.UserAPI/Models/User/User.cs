namespace MeowUserAccount.UserAPI.Data;

public class User
{
    public string? Uuid { get; set; } // UUID
    public int? DatabaseId { get; set; } // 用户库ID
    public string? Uid { get; set; } // UID
    public string? Name { get; set; } // 用户名
    public string? Password { get; set; } // 密码
    public string? Salt { get; set; } // 密码盐
    public string? Email { get; set; } // 电子邮箱
    public string? phone { get; set; } // 手机号
    public int? EmailState { get; set; } // 电子邮箱状态
    public int? PhoneState { get; set; } // 手机号状态
    public int? State { get; set; } // 账号状态
    public int? Type { get; set; } // 用户类型
    public string? CurrentIp { get; set; } // 当前IP
    public DateTime? RegisterTime { get; set; } // 注册时间
}