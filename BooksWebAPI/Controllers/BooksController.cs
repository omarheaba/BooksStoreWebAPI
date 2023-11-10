using BooksWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksContext booksContext { get; set; }

        public BooksController(BooksContext _booksContext)
        {
            this.booksContext = _booksContext;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<BookModel> GetAllBooks()
        {
            return this.booksContext.Books.Include(book => book.Author).ToList();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public BookModel GetBookById(int id)
        {
            return this.booksContext.Books.Include(book => book.Author).First(book => book.BookId == id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public void AddNewBook([FromBody] BookModel bookObject)
        {
            this.booksContext.Books.Add(bookObject);
            this.booksContext.SaveChanges();
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void EditBook(int id, [FromBody] BookModel bookObject)
        {
            BookModel currentBook = this.GetBookById(id);

            currentBook.BookTitle = bookObject.BookTitle;
            currentBook.AuthorId = bookObject.AuthorId;

            this.booksContext.SaveChanges();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            BookModel currentBook = this.GetBookById(id);

            this.booksContext.Books.Remove(currentBook);
            this.booksContext.SaveChanges();
        }
    }
}
