using Data.Models;

namespace LibrarySystem.Data.DTOs;
public class BookDto
{
    public Guid  BookId { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string ISBN { get; set; }
    public Guid  AuthorId { get; set; }
    public Guid  CategoryId { get; set; }
    public Author Author { get; set; }
    public Category Category { get; set; }
    public ICollection<Loan> Loans { get; set; }
    public ICollection<BookCopy> Copies { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}
