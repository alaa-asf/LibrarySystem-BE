using Data.Models;

namespace LibrarySystem.Data.DTOs;

public class AuthorDto
{
    public Guid  AuthorId { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Book> Books { get; set; }
}
