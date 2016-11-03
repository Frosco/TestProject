using System;
using System.Collections.Generic;

namespace NilsOchMartin.Models.Entities
{
    public partial class OwnerCarRelations
    {
        public int OwnerId { get; set; }
        public int CarId { get; set; }

        public virtual Car Car { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
