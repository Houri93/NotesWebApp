using Microsoft.EntityFrameworkCore;

using NotesWebApp.Data;

namespace NotesWebApp.Services;

public class DbCon : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@$"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog={nameof(NotesWebApp)}DB;Integrated Security=True;");
        base.OnConfiguring(optionsBuilder);
    }
}
