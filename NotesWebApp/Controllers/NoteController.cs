using Microsoft.AspNetCore.Mvc;

using NotesWebApp.Data;
using NotesWebApp.Services;

namespace NotesWebApp.Controllers;

public class NoteController : BaseController
{
    private readonly NoteService noteService;

    public NoteController(NoteService noteService)
    {
        this.noteService = noteService;
    }

    [HttpGet]
    public Note Add()
    {
        var note = noteService.Add();
        return note;
    }
    
    [HttpGet]
    public IEnumerable<Note> GetAll()
    {
        var notes = noteService.GetAll();
        return notes;
    }


}
