using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string SSN { get; set; }
        [Computed]
        public List<Note> Notes { get; set; }
        public int Age { get; set; }
    }
}
