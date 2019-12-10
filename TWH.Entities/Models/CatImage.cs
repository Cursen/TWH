using System;
using System.Collections.Generic;
using System.Text;

namespace TWH.Entities.Models
{
    public class CatImage : BaseEntityID<Guid>
    {
        //TODO ensure proper setup of this class, in terms of GUID etc.
        //one-to-one association in order to manage lazy loading.
        public int CatId { get; private set; }
        public byte[] Image { get; set; }
    }
}
