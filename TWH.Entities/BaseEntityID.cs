using System;
using System.Collections.Generic;
using System.Text;

namespace TWH.Entities
{
    public abstract class EntityBaseID<Guid>
    {
        public Guid Id { get; protected set; }
    }
}
