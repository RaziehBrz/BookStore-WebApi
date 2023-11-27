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
    }
}