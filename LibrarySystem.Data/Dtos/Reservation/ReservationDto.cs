using Data.Models;

namespace LibrarySystem.Data.DTOs;
public class ReservationDto
{
    public Guid  ReservationId { get; set; } = Guid.NewGuid();
    public Guid  BookId { get; set; }
    public Guid  CustomerId { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public ReservationStatus Status { get; set; }
    public Book Book { get; set; }
    public Customer Customer { get; set; }
}
