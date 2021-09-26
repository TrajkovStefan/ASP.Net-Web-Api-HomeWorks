using SEDC.NotesApp.Domain.Models;
using SEDC.NotesApp.Dtos.Notes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Mappers.Notes
{
    public static class NoteMapper
    {
        public static NoteDto ToNoteDto(this Note note)
        {
            return new NoteDto
            {
                Text = note.Text,
                Color = note.Color,
                Tag = note.Tag,
                UserFullname = $"{note.User.FirstName} {note.User.LastName}"
            };
        }

        public static Note ToNote(this AddUpdateNoteDto addNoteDto)
        {
            return new Note
            {
                Text = addNoteDto.Text,
                Color = addNoteDto.Color,
                Tag = addNoteDto.Tag,
                UserId = addNoteDto.UserId
            };
        }
    }
}
