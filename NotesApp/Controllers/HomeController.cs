using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotesApp.Core.Models;
using NotesApp.Core.Services;
using NotesApp.ViewElements.Models;

namespace NotesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotesService _notesService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, INotesService notesService, IMapper mapper)
        {
            _logger = logger;
            _notesService = notesService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            return View(new CreateNoteViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNoteViewModel noteViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var note = _mapper.Map<NoteModel>(noteViewModel);
                    await _notesService.CreateNote(note);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View("Index", noteViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> LoadEditForm(int id)
        {
            try
            {
                var note = await _notesService.GetNoteById(id);
                return PartialView("_NoteFormEdit", _mapper.Map<EditNoteViewModel>(note));
            }
            catch
            {
                return View("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditNoteViewModel noteViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var noteToBeUpdated = await _notesService.GetNoteById(noteViewModel.Id);
                    await _notesService.UpdateNote(noteToBeUpdated, _mapper.Map<NoteModel>(noteViewModel));
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View("Index", noteViewModel);
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteAjax(int id)
        {
            try
            {
                var noteToBeDeleted = await _notesService.GetNoteById(id);
                await _notesService.DeleteNote(noteToBeDeleted);
                return BuildResponse(new { Message = "Eliminado correctamente" });
            }
            catch
            {
                return BuildResponse(new { Message = $"Algo paso y no se pudo eliminar la nota con id: {id}" }, false);
            }
        }

        private JsonResult BuildResponse(object body, bool ok = true)
        {
            return new JsonResult(new { body, ok });
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
