using LibrarySystem.Data.Models.core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Loan : Entity<Guid>
    {
        public Guid  LoanId { get; set; }

        public Guid  BookId { get; set; }
        public Guid  BookCopyId { get; set; }
        public Guid  CustomerId { get; set; }

        [DataType(DataType.Date)]
        public DateTime LoanDate { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; } = DateTime.UtcNow.AddDays(14);

        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        public Book Book { get; set; }
        public Customer Customer { get; set; }
        public BookCopy BookCopy { get; set; }
        public bool IsOverdue => !ReturnDate.HasValue && DueDate < DateTime.UtcNow;

    }
}
