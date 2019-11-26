using System;
using System.Collections.Generic;
using System.Text;

namespace TWH.Entities.Models
{
    public class Room : EntityBaseID<Guid>
    {
        public Guid ID { get; set; }
        public int Number { get; set; }
        public int MaxCats { get; set; }
    }
}
