using System;
using System.ComponentModel.DataAnnotations;

namespace NotesApp.ViewElements.Models
{
    public class EditNoteViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
