using SEDC.NotesApp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Dtos.Notes
{
    public class AddUpdateNoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public TagEnum Tag { get; set; }
        public int UserId { get; set; }
    }
}
