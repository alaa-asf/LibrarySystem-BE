using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Data.DTOs;
public class UpdateReservationDto
{
    [Required]
    public Guid ReservationId { get; set; }

    [Required]
    public Guid BookId { get; set; }

    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public DateTime ReservationDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    [Required]
    public ReservationStatus Status { get; set; }
}
