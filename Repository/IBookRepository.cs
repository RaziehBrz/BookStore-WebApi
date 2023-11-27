using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore_WebApi.Models;

namespace BookStore_WebApi.Repository
{
    public interface IBookRepository
    {
        Task<List<BookDetailsDto>> GetAllBooks();
    }
}