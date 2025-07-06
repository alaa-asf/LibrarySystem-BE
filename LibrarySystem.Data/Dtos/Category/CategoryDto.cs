using Data.Models;

namespace LibrarySystem.Data.DTOs;
public class CategoryDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public Guid? ParentCategoryId { get; set; }

    public ParentInfoDto Parent { get; set; }

    public List<CategoryDto> SubCategories { get; set; } = new();

    public List<BookDto> Books { get; set; } = new();
}

public class ParentInfoDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}