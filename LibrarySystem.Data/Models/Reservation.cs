using LibrarySystem.Data.Models.core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Reservation : Entity<Guid>
    {
        public Guid  ReservationId { get; set; }
        public Guid  BookId { get; set; }
        public Guid  CustomerId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTime? ExpirationDate { get; set; } 
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

        public Book Book { get; set; }
        public Customer Customer { get; set; }
    }

    public enum ReservationStatus
    {
        Pending,
        Fulfilled,
        Canceled,
        Expired
    }
}
