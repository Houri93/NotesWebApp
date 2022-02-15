using System.Security.Cryptography;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using NotesWebApp.Services;

namespace NotesWebApp.Controllers;

public class BaseController : Controller
{
    private const string AuthCookieName = "auth_id";

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var userService = this.HttpContext.RequestServices.GetService<UserService>();

        var request = this.HttpContext.Request;
        var cookies = request.Cookies;

        if (cookies.TryGetValue(AuthCookieName, out var idString)
            && Guid.TryParse(idString, out var userId)
            && userService.Find(userId) is not null)
        {

        }
        else
        {
            this.Redirect("User/Login");
        }
        base.OnActionExecuting(context);
    }
}