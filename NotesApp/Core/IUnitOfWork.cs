using System;
using System.Threading.Tasks;
using NotesApp.Core.Repositories;

namespace NotesApp.Core
{
    public interface IUnitOfWork : IDisposable
    {
        INotesRepository Notes { get; }
        Task<int> CommitAsync();
    }
}
