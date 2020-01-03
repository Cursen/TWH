using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;
using TWH.Repository;

namespace TWH.Services.Services
{
    public class UserService : BaseService<Room, Guid>
    {
        public UserService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            Repository = new UserRepository(unitOfWork);
        }
    }
}
