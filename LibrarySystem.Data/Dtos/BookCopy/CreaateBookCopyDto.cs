using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Data.DTOs;
public class CreateBookCopyDto
{
    [Required]
    public Guid BookId { get; set; }

    [Required]
    public string CopyNumber { get; set; }

    public bool IsAvailable { get; set; } = true;
}
