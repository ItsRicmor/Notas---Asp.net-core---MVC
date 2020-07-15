using System;
using AutoMapper;
using NotesApp.Core.Models;
using NotesApp.ViewElements.Models;

namespace NotesApp.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<NoteModel, CreateNoteViewModel>().ReverseMap();
            CreateMap<NoteModel, EditNoteViewModel>().ReverseMap();
        }
    }
}
