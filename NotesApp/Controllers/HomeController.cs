using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotesApp.Core.Models;
using NotesApp.Core.Services;

namespace NotesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotesService _notesService;

        public HomeController(ILogger<HomeController> logger, INotesService notesService)
        {
            _logger = logger;
            _notesService = notesService;
        }

        // public async Task<IActionResult> Index()
        public IActionResult Index()
        {
            // var note = new NoteModel { Title = "Cita", Description = "Cita de dientes" };
            // await _notesService.CreateNote(note);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
