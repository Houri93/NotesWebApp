using NotesWebApp.Data;

namespace NotesWebApp.Services;

public class NoteService
{
    private readonly DbCon db;
    private readonly UserService userService;

    public NoteService(DbCon db, UserService userService)
    {
        this.db = db;
        this.userService = userService;
    }

    public Note Add()
    {    
        // create new note object
        var note = new Note();
        // assign new guid id to new note object
        note.Id = Guid.NewGuid();    
        // add new note object to db
        db.Notes.Add(note);
        // save db
        db.SaveChanges();
        //return object
        return note;
    }
    public void Remove(Guid id)
    {
        db.Notes.Remove(Find(id));
        db.SaveChanges();
    }
    public Note Find(Guid id)
    {
        var note = db.Notes.Find(id);
        return note;
    }
    public void UpdateTitle(Guid id, string title)
    {
        var note = Find(id);
        note.Title = title;
        db.SaveChanges();
    }
    public void UpdateText(Guid id, string text)
    {
        var note = Find(id);
        note.Text = text;
        db.SaveChanges();
    }

    public IEnumerable<Note> GetAll()
    {
        return db.Notes.ToArray();
    }

}
