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

    internal User Find(Guid userId)
    {
        return db.Users.Find(userId);
    }

    internal User TryLogin(string username, string password)
    {
        user = db.Users.FirstOrDefault(a => a.Username.ToLower() == username.ToLower() && a.Password == password);
        return user;
    }
}
