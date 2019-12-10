using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;
using TWH.Repository;

namespace TWH.Services.Services
{
    public class CatService : BaseService<Cat, Guid>
    {
        public CatService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            Repository = new CatRepository(unitOfWork);
        }
    }
}
