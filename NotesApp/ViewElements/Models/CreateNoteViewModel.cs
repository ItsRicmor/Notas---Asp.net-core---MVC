using System;
using System.ComponentModel.DataAnnotations;

namespace NotesApp.ViewElements.Models
{
    public class CreateNoteViewModel
    {
        [Required(ErrorMessage = "El titulo es obligatorio")]
        [StringLength(40, MinimumLength = 10, ErrorMessage = "La descripcion debe tener de 10 a 40 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(100, MinimumLength = 7, ErrorMessage = "La descripcion debe tener de 7 a 100 caracteres")]
        public string Description { get; set; }
    }
}
