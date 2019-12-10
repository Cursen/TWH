using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;
using TWH.Repository;
using TWH.Repository.EntityRepositories;

namespace TWH.Services.Services
{
    public class CatImageService : BaseService<catImage, Guid>
    {
        public CatImageService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            Repository = new CatImageRepository(unitOfWork);
        }
    }
}
