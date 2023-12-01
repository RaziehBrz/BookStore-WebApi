using System.Threading.Tasks;
using BookStore_WebApi.Models;
using BookStore_WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore_WebApi.AddControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookRepository bookRepository, ILogger<BooksController> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        [HttpGet]
        //Get all books
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("{id}")]
        //Get single book by id
        public async Task<IActionResult> GetDetailsById(int id)
        {
            var book = await _bookRepository.GetDetailsById(id);
            if (book is null) return NotFound();
            return Ok(book);
        }
        [HttpPost]
        //Add a new book to DB
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto model)
        {
            var id = await _bookRepository.CreateBook(model);
            return Ok(id);
            //return Created(...);
        }

        [HttpPut("{id}")]
        //Update a book by Id
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDto model, int id)
        {
            var result = await _bookRepository.UpdateBook(id, model);

            if (result) return Ok(result);
            return BadRequest("This book is not exist!");
        }
        [HttpDelete("{id}")]
        //Delete a book by Ud
        public async Task<IActionResult> RemoveBook(int id)
        {
            var result = await _bookRepository.RemoveBook(id);
            if (result) return Ok(result);
            return BadRequest("This book is not exit!");
        }

    }
}