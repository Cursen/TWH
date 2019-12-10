using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;

namespace TWH.Repository.EntityRepositories
{
    public class CatImageRepository : BaseRepository<catImage, Guid>
    {
        public CatImageRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
