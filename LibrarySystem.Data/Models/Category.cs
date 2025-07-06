using LibrarySystem.Data.Models.core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Category : Entity<Guid>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
