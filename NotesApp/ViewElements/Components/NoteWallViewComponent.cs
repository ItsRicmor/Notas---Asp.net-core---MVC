using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Core.Services;

namespace NotesApp.ViewElements.Components
{
    [ViewComponent(Name = "NoteWall")]
    public class NoteWallViewComponent : ViewComponent
    {
        private readonly INotesService _notesService;

        public NoteWallViewComponent(INotesService notesService)
        {
            _notesService = notesService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notes = await _notesService.GetAllNotes();
            return View(notes);
        }
    }
}
