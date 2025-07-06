using Data.Models;
using LibrarySystem.Repositories;

namespace Data.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
        }

        // add any Author-specific methods here if needed
    }
}
