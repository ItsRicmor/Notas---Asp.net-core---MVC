using System;
using System.Threading.Tasks;
using NotesApp.Core;
using NotesApp.Core.Repositories;
using NotesApp.Data.Repositories;

namespace NotesApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private NotesRepository _notesRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public INotesRepository Notes => _notesRepository ??= new NotesRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
