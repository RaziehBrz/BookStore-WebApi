using Microsoft.EntityFrameworkCore;

namespace BookStore_WebApi.Data
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }

    }
}