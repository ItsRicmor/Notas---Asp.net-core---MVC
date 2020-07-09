using System;
using Microsoft.AspNetCore.Mvc;

namespace NotesApp.Components
{
    [ViewComponent(Name = "NoteForm")]
    public class NoteFormViewComponent : ViewComponent
    {
        public NoteFormViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}