using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Dtos.Category
{
    public class UpdateCategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
