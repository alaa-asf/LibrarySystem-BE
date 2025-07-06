using Data.Models;

namespace LibrarySystem.Data.DTOs;
public class LoanDto
{
    public Guid  LoanId { get; set; } = Guid.NewGuid();
    public Guid  BookId { get; set; }
    public Guid  BookCopyId { get; set; }
    public Guid  CustomerId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public Book Book { get; set; }
    public Customer Customer { get; set; }
    public BookCopy BookCopy { get; set; }
}
