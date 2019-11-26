using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;

namespace TWH.Repository
{
    class BookingRepository : BaseRepository<Booking>
    {
        public BookingRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
