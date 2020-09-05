using BooksRent_Api.Modals;
using Microsoft.EntityFrameworkCore;

namespace BusinessEntity.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Book> Book { get; set; }
    }
}
