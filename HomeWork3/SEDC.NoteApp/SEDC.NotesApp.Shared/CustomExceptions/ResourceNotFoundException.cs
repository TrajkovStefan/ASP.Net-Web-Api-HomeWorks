using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Shared.CustomExceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(int id, string message) : base(message)
        {
            //ldg id

        }
    }
}
