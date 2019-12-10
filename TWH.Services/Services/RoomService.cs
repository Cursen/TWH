using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;
using TWH.Repository;

namespace TWH.Services.Services
{
    public class RoomService : BaseService<Room, Guid>
    {
        public RoomService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            Repository = new RoomRepository(unitOfWork);
        }
    }
}
