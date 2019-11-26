using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;

namespace TWH.Repository
{
    public class CatRepository : BaseRepository<Cat>
    {
        public CatRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
