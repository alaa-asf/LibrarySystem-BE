using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Models.core
{
    public abstract class Entity<TId>
    {
        public TId Id { get; set; }
        //public bool IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }

    }
}
