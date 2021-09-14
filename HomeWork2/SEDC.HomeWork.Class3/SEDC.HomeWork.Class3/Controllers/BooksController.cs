using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.HomeWork.Class3.Helpers;
using SEDC.HomeWork.Class3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.HomeWork.Class3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }
        
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            try
            {
                return Ok(_bookService.GetAll());
            }
            catch (Exception e)
            {
                //log e.Message
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("queryString")]
        public ActionResult<List<Book>> FilterBookByAuthorAndTitle(string author, string title)
        {
            try
            {
                if(string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "You have to send at least one filter parameter!");
                }
                if (string.IsNullOrEmpty(author))
                {
                    List<Book> booksDb = StaticDb.Books.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
                    return Ok(booksDb);
                }
                if (string.IsNullOrEmpty(title))
                {
                    List<Book> booksDb = StaticDb.Books.Where(x => x.Author.ToLower().Contains(author.ToLower())).ToList();
                    return Ok(booksDb);
                }
                List<Book> filteredBooks = StaticDb.Books.Where(x => x.Author.ToLower().Contains(author.ToLower())
                                                          && x.Title.ToLower().Contains(title.ToLower())).ToList();
                return Ok(filteredBooks);
            }
            catch(Exception e)
            {
                //log e
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpPost("postBook")]
        public IActionResult PostBook([FromBody] Book book)
        {
            try
            {
                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "Book was added!");
            }
            catch(Exception e)
            {
                //log e
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpPost("titles")]
        public ActionResult<List<string>> ListOfTitles([FromBody] List<Book> books)
        {
            try
            {
                List<string> allTitles = books.Select(x => x.Title).ToList();
                return Ok(allTitles);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _bookService.AddBook(book);
            return Ok();
        }
    }
}
