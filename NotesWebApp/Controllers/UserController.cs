using NotesWebApp.Data;
using NotesWebApp.Services;

namespace NotesWebApp.Controllers;

public class UserController : BaseController
{
    private readonly UserService userService;

    public UserController(UserService userService)
    {
        this.userService = userService;
    }
    public User TryLogin(string username, string password)
    {
        return userService.TryLogin(username, password);
    }
}
