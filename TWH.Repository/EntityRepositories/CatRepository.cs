using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;

namespace TWH.Repository
{
    public class CatRepository : BaseRepository<Cat, Guid>
    {
        public CatRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
