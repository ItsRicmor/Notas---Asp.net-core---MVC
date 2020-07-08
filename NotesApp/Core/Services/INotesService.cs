using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotesApp.Core.Models;

namespace NotesApp.Core.Services
{
    public interface INotesService
    {
        Task<IEnumerable<NoteModel>> GetAllNotes();
        Task<NoteModel> GetNoteById(int id);
        Task<NoteModel> CreateNote(NoteModel note);
        Task UpdateNote(NoteModel noteToBeUpdated, NoteModel note);
        Task DeleteNote(NoteModel note);
    }
}
