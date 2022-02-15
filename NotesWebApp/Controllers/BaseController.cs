using System.Security.Cryptography;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using NotesWebApp.Services;

namespace NotesWebApp.Controllers;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public class BaseController : Controller
{
    private const string AuthCookieName = "auth_id";
    private const string LoginUrl = "User/Login";

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var userService = this.HttpContext.RequestServices.GetService<UserService>();

        var request = this.HttpContext.Request;
        var cookies = request.Cookies;

        if (request.Path.ToString().ToLower() != LoginUrl.ToLower()
            && cookies.TryGetValue(AuthCookieName, out var idString)
            && Guid.TryParse(idString, out var userId)
            && userService.Find(userId) is not null)
        {
            base.OnActionExecuting(context);
        }
        else
        {
            context.Result = this.Redirect(LoginUrl);
        }
    }
}