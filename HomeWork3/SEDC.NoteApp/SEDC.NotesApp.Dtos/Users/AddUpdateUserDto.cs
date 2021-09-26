﻿using SEDC.NotesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Dtos.Users
{
    public class AddUpdateUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
    }
}
