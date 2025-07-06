using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Data.DTOs;
public class UpdateLoanDto
{
    [Required]
    public Guid LoanId { get; set; }

    [Required]
    public Guid BookId { get; set; }

    [Required]
    public Guid BookCopyId { get; set; }

    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public DateTime LoanDate { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }
}
