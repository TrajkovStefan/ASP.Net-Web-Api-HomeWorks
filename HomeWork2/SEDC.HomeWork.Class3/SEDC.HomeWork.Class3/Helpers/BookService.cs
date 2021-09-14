using SEDC.HomeWork.Class3.DataAccess;
using SEDC.HomeWork.Class3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.HomeWork.Class3.Helpers
{
    public class BookService
    {
        private BookAppDbContext _dbContext;

        public BookService(BookAppDbContext bookService)
        {
            _dbContext = bookService;
        }

        public List<Book> GetAll()
        {
            return _dbContext.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _dbContext.Books.FirstOrDefault(x => x.Id == id);
        }

        public void AddBook(BookVM newBook)
        {
            _dbContext.Books.Add(new Book
            {
                Title = newBook.Title,
                Author = newBook.Author
            });
            _dbContext.SaveChanges();
        }
    }
}
