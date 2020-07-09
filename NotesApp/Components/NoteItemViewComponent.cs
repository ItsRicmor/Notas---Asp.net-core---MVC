using System;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Core.Models;

namespace NotesApp.Components
{
    [ViewComponent(Name = "NoteItem")]
    public class NoteItemViewComponent : ViewComponent
    {
        public NoteItemViewComponent()
        {
        }

        public IViewComponentResult Invoke(NoteModel note)
        {
            return View(note);
        }
    }
}
