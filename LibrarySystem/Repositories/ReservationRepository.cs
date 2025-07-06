using Data.Models;
using LibrarySystem.Repositories;

namespace Data.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
        }

        // add any Author-specific methods here if needed
    }
}
