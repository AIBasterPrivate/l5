using l4.Models;
using Microsoft.EntityFrameworkCore;

namespace l4.Data
{
    public class DbConnection : DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<BookOutOfStorage> BookOutOfStorages { get; set; } = null!;
    }
}
