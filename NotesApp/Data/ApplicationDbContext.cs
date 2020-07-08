using Microsoft.EntityFrameworkCore;
using NotesApp.Core.Models;

namespace NotesApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<NoteModel> Notes { get; set; }
    }
}
