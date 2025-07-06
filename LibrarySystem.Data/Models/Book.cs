using LibrarySystem.Data.Models.core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Book : Entity<Guid>
    {
        public Guid BookId { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [StringLength(20)]
        public string ISBN { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public ICollection<BookCopy> Copies { get; set; } = new List<BookCopy>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
