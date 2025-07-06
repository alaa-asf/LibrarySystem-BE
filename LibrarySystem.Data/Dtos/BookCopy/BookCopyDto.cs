using Data.Models;

namespace LibrarySystem.Data.DTOs;
public class BookCopyDto
{
    public Guid  CopyId { get; set; } = Guid.NewGuid();
    public Guid  BookId { get; set; }
    public string CopyNumber { get; set; }
    public bool IsAvailable { get; set; }
    public Book Book { get; set; }
    public ICollection<Loan> Loans { get; set; }
}
