using System;
using System.Collections.Generic;

namespace NilsOchMartin.Models.Entities
{
    public partial class Car
    {
        public Car()
        {
            OwnerCarRelations = new HashSet<OwnerCarRelations>();
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public int Doors { get; set; }
        public int? TopSpeed { get; set; }

        public virtual ICollection<OwnerCarRelations> OwnerCarRelations { get; set; }
    }
}
