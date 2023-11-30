using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore_WebApi.Data;
using BookStore_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore_WebApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        //Get all books from DB
        public async Task<List<BookDetailsDto>> GetAllBooks()
        {
            var books = await _context.Book.Select(x =>
            new BookDetailsDto()
            {
                Id = x.Id,
                Amount = x.Amount,
                Despription = x.Despription,
                Title = x.Title,
                page = x.page
            })
           .ToListAsync();
            return books;
        }
        //Get single book by Id
        public async Task<BookDetailsDto> GetDetailsById(int id)
        {
            var book = await _context.Book.Where(x => x.Id == id)
                                          .Select(x => new BookDetailsDto()
                                          {
                                              Id = x.Id,
                                              Amount = x.Amount,
                                              Despription = x.Despription,
                                              Title = x.Title,
                                              page = x.page
                                          }).FirstOrDefaultAsync();
            return book;
        }

        //Add a book to DB
        public async Task<int> CreateBook(CreateBookDto model)
        {
            var book = new Book()
            {
                Amount = model.Amount,
                Title = model.Title,
                Despription = model.Despription,
                page = model.page
            };
            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        //Update a book by Id
        public async Task<bool> UpdateBook(int id, UpdateBookDto model)
        {
            //Get a book by id

            /*
             var book = new Book()
            {
                Id = id ,
                Amount = model.Amount,
                Title = model.Title,
                Despription = model.Despription,
                page = model.page
            };
            _context.Book.Update(book);
             await _context.SaveChangesAsync();
             return true;
            */
            var book = await _context.Book.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (book != null)
            {
                book.Title = model.Title;
                book.Amount = model.Amount;
                book.Despription = model.Despription;
                book.page = model.page;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}