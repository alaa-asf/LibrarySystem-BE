using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Data.DTOs;
public class CreateCustomerDto
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
}
