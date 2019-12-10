using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;
using TWH.Repository;

namespace TWH.Services.Services
{
    public class CatImageService : BaseService<CatImage, Guid>
    {
        public CatImageService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            Repository = new CatImageService(unitOfWork);
        }
    }
}
