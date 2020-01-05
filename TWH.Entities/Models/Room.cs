using System;
using System.Collections.Generic;
using System.Text;

namespace TWH.Entities.Models
{
    public class Room : BaseEntityID<Guid>
    {
        public int Number { get; set; }
        public int MaxCats { get; set; }
        public Room()
        {
            Id = Guid.NewGuid();
        }
    }
}
