namespace MeowUserAccount.UserAPI.Models.Admin;

public class AddDatabase : Base
{
    public string Name { get; set; }
    public int State { get; set; }
    public string Notes { get; set; }
}