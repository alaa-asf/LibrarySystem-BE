using Data.Models;
using LibrarySystem.Repositories;

namespace Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        // add any Author-specific methods here if needed
    }
}
