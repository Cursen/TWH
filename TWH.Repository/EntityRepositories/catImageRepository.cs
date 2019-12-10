using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;

namespace TWH.Repository.EntityRepositories
{
    public class catImageRepository : BaseRepository<CatImage, Guid>
    {
        public catImageRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
