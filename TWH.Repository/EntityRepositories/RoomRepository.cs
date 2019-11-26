using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;

namespace TWH.Repository
{
    public class RoomRepository : BaseRepository<Room>
    {
        public RoomRepository(UnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }

    }
}
