using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotesApp.Core;
using NotesApp.Core.Models;
using NotesApp.Core.Services;

namespace NotesApp.Services
{
    public class NotesService : INotesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<NoteModel> CreateNote(NoteModel note)
        {
            await _unitOfWork.Notes.AddAsync(note);
            await _unitOfWork.CommitAsync();
            return note;
        }

        public async Task DeleteNote(NoteModel note)
        {
            _unitOfWork.Notes.Remove(note);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<NoteModel>> GetAllNotes()
        {
            return await _unitOfWork.Notes.GetAllAsync();
        }

        public async Task<NoteModel> GetNoteById(int id)
        {
            return await _unitOfWork.Notes.GetByIdAsync(id);
        }

        public async Task UpdateNote(NoteModel noteToBeUpdated, NoteModel note)
        {
            noteToBeUpdated.Title = note.Title;
            noteToBeUpdated.Description = note.Description;
            await _unitOfWork.CommitAsync();
        }
    }
}
