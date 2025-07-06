using LibrarySystem.Data.Models.core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Customer : Entity<Guid>
    {
        public Guid CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
