using System;
using System.Collections.Generic;
using System.Text;

namespace TWH.Entities
{
    public abstract class BaseEntityID<TEntityIdType>
    {
        public TEntityIdType Id { get; protected set; }
    }
}
