using Microsoft.EntityFrameworkCore;
using WebMyBookStoreApi.Model;

namespace WebMyBookStoreApi.Context
{
    public class MyBookStoreDbContext : DbContext
    {
        public const string connectionString = @"Data Source=JAVIMEGA;User ID=sa;Password=manager;Database=MyBookStore;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;";
        public MyBookStoreDbContext(DbContextOptions<MyBookStoreDbContext> options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
