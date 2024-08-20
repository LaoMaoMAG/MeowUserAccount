
namespace MeowUserAccount.UserAPI.Services.Admin.AdminUser;

using Microsoft.AspNetCore.Mvc;

[Route("api/admin/admin_user/manage")]
[ApiController]
public class Manage : ControllerBase
{
    [HttpPost]
    public ActionResult AddUser([FromBody] Models.Admin.Base request)
    {
        return Ok();
    }
}