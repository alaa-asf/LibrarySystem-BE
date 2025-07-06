using LibrarySystem.Data.Models.core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Author : Entity<Guid>
    {
        public Guid AuthorId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();

        public string FullName => $"{FirstName} {LastName}";
    }
}
