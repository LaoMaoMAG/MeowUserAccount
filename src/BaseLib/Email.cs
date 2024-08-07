using System.Net;
using System.Net.Mail;

namespace BaseLib;

public class Email
{
    // 服务器邮箱列表
    private static readonly Dictionary<string, ServerEmailData> _serverEmailList = new();
    
    
    /// <summary>
    /// 服务器邮箱数据
    /// </summary>
    public class ServerEmailData
    {
        //邮箱服务器名称
        public string Name { get; set; }
        // 邮件服务器地址
        public string Server { get; set; }
        // 邮件服务器端口
        public int Port { get; set; }
        // 用户名
        public string UserName { get; set; }
        // 密码
        public string Password { get; set; }
        // 发件人邮箱
        public string FromEmail { get; set; }
    }

    
    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <param name="serverEmail"></param>
    /// <param name="toEmail"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    public bool SendEmail(string serverEmail, string toEmail, string subject, string body)
    {
        return SendEmail(_serverEmailList[serverEmail], toEmail, subject, body);
    }
    
    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <param name="serverEmail"></param>
    /// <param name="toEmail"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    public bool SendEmail(ServerEmailData serverEmail, string toEmail, string subject, string body)
    {
        try
        {
            // 创建 MailMessage 对象
            MailMessage mail = new MailMessage
            {
                From = new MailAddress(serverEmail.FromEmail),
                Subject = subject,
                Body = body
            };
            mail.To.Add(toEmail);
            // 创建 SmtpClient 对象
            SmtpClient smtpClient = new SmtpClient(serverEmail.Server, serverEmail.Port)
            {
                Credentials = new NetworkCredential(serverEmail.UserName, serverEmail.Password),
                EnableSsl = true // 如果你的 SMTP 服务器需要 SSL
            };
            // 发送邮件
            smtpClient.Send(mail);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    
    /// <summary>
    /// 添加服务器邮箱
    /// </summary>
    public bool AddServerEmail(string id, ServerEmailData serverEmailData)
    {
        try
        {
            _serverEmailList.Add(id, serverEmailData);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    /// <summary>
    /// 设置服务器邮箱
    /// </summary>
    public bool SetServerEmail(string id, ServerEmailData serverEmailData)
    {
        try
        {
            _serverEmailList[id] = serverEmailData;
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    /// <summary>
    /// 获取服务器邮箱
    /// </summary>
    public ServerEmailData? GetServerEmail(string id)
    {
        try
        {
            return _serverEmailList[id];
        }
        catch (Exception e)
        {
            return null;
        }
    }

    /// <summary>
    /// 删除服务器邮箱
    /// </summary>
    public bool DeleteServerEmail(string id)
    {
        try
        {
            _serverEmailList.Remove(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    /// <summary>
    /// 获取服务器邮箱列表
    /// </summary>
    public string[]? GetServerEmailList()
    {
        try
        {
            // 获取所有键的集合
            ICollection<string> keys = _serverEmailList.Keys;
            // 将键集合转换为 string 数组
            string[]? keyArray = new string[keys.Count];
            keys.CopyTo(keyArray, 0);
            return keyArray;
        }
        catch (Exception e)
        {
            return null;
        }
        
    }
}