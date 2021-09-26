using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Shared.CustomExceptions
{
    public class NoteException : Exception
    {
        public NoteException(string message) : base(message)
        {

        }
    }
}
