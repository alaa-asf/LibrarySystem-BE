using Data.Models;
using Data.Repositories;
using LibrarySystem.Repositories;

namespace Data.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}
