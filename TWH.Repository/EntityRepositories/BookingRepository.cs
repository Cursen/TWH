using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities;
using TWH.Entities.Models;

namespace TWH.Repository
{
    public class BookingRepository : BaseRepository<Booking, Guid>
    {
        public BookingRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
