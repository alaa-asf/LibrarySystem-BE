using Data.Models;
using LibrarySystem.Repositories;

namespace Data.Repositories
{
    public class BookCopyRepository : GenericRepository<BookCopy>, IBookCopyRepository
    {
        public BookCopyRepository(ApplicationDbContext context) : base(context)
        {
        }

        // add any Author-specific methods here if needed
    }
}
