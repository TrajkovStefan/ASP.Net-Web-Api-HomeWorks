using SEDC.HomeWork.Class3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.HomeWork.Class3
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book(){ Title = "Book1", Author = "Author1"},
            new Book(){ Title = "Book2", Author = "Author2" },
            new Book(){ Title = "Book3", Author = "Author3" },
        };
    }
}
