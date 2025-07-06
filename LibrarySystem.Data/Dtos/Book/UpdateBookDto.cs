using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Dtos.Book
{
    public class UpdateBookDto
    {
        [Required]
        public Guid BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}
