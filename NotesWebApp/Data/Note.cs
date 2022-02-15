namespace NotesWebApp.Data;

public class Note
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
}
