using System;
using System.Collections.Generic;

namespace NilsOchMartin.Models.Entities
{
    public partial class Owner
    {
        public Owner()
        {
            OwnerCarRelations = new HashSet<OwnerCarRelations>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<OwnerCarRelations> OwnerCarRelations { get; set; }
    }
}
