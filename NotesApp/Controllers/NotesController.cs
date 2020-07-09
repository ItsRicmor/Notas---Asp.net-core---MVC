using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using NotesApp.Core.Models;
using NotesApp.Core.Services;

namespace NotesApp.Controllers
{
    public class NotesController : Controller
    {

        private readonly INotesService _notesService;

        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> GetById(int id)
        {
            try
            {
                var note = await _notesService.GetNoteById(id);
                return BuildResponse(note);
            }
            catch
            {
                return BuildResponse(new { Message = $"No se encontro una nota con el id: {id}" }, false);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create(NoteModel note)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _notesService.CreateNote(note);
                    return BuildResponse(note);
                }
                return BuildResponse(new { Message = "Todos los campos de la nota son obligatorios" }, false);
            }
            catch
            {
                return BuildResponse(new { Message = "Algo paso y no se pudo crear la nota" }, false);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<JsonResult> Edit(int id, NoteModel note)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var noteToBeUpdated = await _notesService.GetNoteById(id);
                    await _notesService.UpdateNote(noteToBeUpdated, note);
                    return BuildResponse(note);
                }
                return BuildResponse(new { Message = "Todos los campos de la nota son obligatorios" }, false);
            }
            catch
            {
                return BuildResponse(new { Message = "Algo paso y no se pudo crear la nota" }, false);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Delete(int id)
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
    }
}