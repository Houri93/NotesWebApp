using NotesWebApp.Data;

namespace NotesWebApp.Services;

public class UserService
{
    private readonly DbCon db;

    private User user;

    public UserService(DbCon db)
    {
        this.db = db;
    }

    public User Find(Guid userId)
    {
        return user = db.Users.Find(userId);
    }

    public User TryLogin(string username, string password)
    {
        return user = db.Users.FirstOrDefault(a => a.Username.ToLower() == username.ToLower() && a.Password == password);
    }
}
