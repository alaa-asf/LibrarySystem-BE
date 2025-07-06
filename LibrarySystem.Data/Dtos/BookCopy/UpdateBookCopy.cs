using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Data.DTOs;
public class UpdateBookCopyDto
{
    [Required]
    public Guid CopyId { get; set; }

    [Required]
    public Guid BookId { get; set; }

    [Required]
    public string CopyNumber { get; set; }

    public bool IsAvailable { get; set; }
}
