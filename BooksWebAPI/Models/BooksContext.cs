using Microsoft.EntityFrameworkCore;

namespace BooksWebAPI.Models
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<BookModel> Books { get; set; }
    }
}
