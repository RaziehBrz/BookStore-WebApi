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
            var books = await _context.Books.Select(x =>
            new BookDetailsDto()
            {
                Id = x.Id,
                Amount = x.Amount,
                Description = x.Description,
                Title = x.Title,
                page = x.page
            })
           .ToListAsync();
            return books;
        }
        //Get single Books by Id
        public async Task<BookDetailsDto> GetDetailsById(int id)
        {
            var Books = await _context.Books.Where(x => x.Id == id)
                                          .Select(x => new BookDetailsDto()
                                          {
                                              Id = x.Id,
                                              Amount = x.Amount,
                                              Description = x.Description,
                                              Title = x.Title,
                                              page = x.page
                                          }).FirstOrDefaultAsync();
            return Books;
        }

        //Add a Books to DB
        public async Task<int> CreateBook(CreateBookDto model)
        {
            var Books = new Book()
            {
                Amount = model.Amount,
                Title = model.Title,
                Description = model.Description,
                page = model.page
            };
            _context.Books.Add(Books);
            await _context.SaveChangesAsync();

            return Books.Id;
        }

        //Update a Books by Id
        public async Task<bool> UpdateBook(int id, UpdateBookDto model)
        {
            //Get a Books by id

            /*
             var Books = new Books()
            {
                Id = id ,
                Amount = model.Amount,
                Title = model.Title,
                Description = model.Description,
                page = model.page
            };
            _context.Books.Update(Books);
             await _context.SaveChangesAsync();
             return true;
            */
            var Books = await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (Books != null)
            {
                Books.Title = model.Title;
                Books.Amount = model.Amount;
                Books.Description = model.Description;
                Books.page = model.page;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        //Delete a Books by Id
        public async Task<bool> RemoveBook(int id)
        {
            /*
            var Books = new Books() {Id = id};
            _context.Remove(Books);
            await _context.SaveChangesAsync(); 
            return true;
            */

            //Get a Books by Id
            var Books = await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (Books != null)
            {
                _context.Remove(Books);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}