using System;
using NotesApp.Core.Models;
using NotesApp.Core.Repositories;

namespace NotesApp.Data.Repositories
{
    public class NotesRepository : Repository<NoteModel>, INotesRepository
    {
        public NotesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
