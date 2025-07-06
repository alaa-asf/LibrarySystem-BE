using LibrarySystem.Data.Models.core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class BookCopy : Entity<Guid>
    {
        [Key]
        public Guid CopyId { get; set; }

        [Required]
        public Guid BookId { get; set; }

        [StringLength(50)]
        public string CopyNumber { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Book Book { get; set; }
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
