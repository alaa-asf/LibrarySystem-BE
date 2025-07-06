using Data.Models;

namespace LibrarySystem.Data.DTOs;
public class CustomerDto
{
    public Guid  CustomerId { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime RegistrationDate { get; set; }
    public ICollection<Loan> Loans { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}
