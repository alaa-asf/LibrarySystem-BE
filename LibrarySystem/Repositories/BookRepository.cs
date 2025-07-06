using Data.Models;
using LibrarySystem.Repositories;

namespace Data.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        // add any Author-specific methods here if needed
    }
}
